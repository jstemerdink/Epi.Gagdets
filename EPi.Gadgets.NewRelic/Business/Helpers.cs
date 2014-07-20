// Copyright© 2014 Jeroen Stemerdink. All Rights Reserved.
// 
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

namespace EPi.Gadgets.NewRelic.Business
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using EPi.Gadgets.NewRelic.Models;

    using EPiServer;
    using EPiServer.Framework.Cache;

    using log4net;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Class Helpers.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        ///     Initializes the <see cref="LogManager">LogManager</see> for the <see cref="Helpers" /> class.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(Helpers));

        internal const string EPiServerNewrelicCacheKey = "EPiServer.NewRelic.{0}";

        #region Public Methods and Operators

        /// <summary>
        /// Formats the bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string FormatBytes(this long bytes)
        {
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            int i = 0;
            double dblSByte = bytes;
            
            if (bytes <= 1024)
            {
                return String.Format(CultureInfo.InvariantCulture, "{0:0.##}{1}", dblSByte, suffix[i]);
            }

            for (i = 0; (bytes / 1024) > 0; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format(CultureInfo.InvariantCulture, "{0:0.##}{1}", dblSByte, suffix[i]);
        }

        /// <summary>
        /// Gets the gadget identifier.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <returns>Guid.</returns>
        public static Guid GetGadgetId(this ControllerContext controllerContext)
        {
            if (controllerContext == null)
            {
                return Guid.Empty;
            }

            Guid gadgetId;

            if (Guid.TryParse(controllerContext.RouteData.Values["gadgetId"] as string, out gadgetId))
            {
                return gadgetId;
            }

            if (Guid.TryParse(HttpContext.Current.Request.QueryString["gadgetId"], out gadgetId))
            {
                return gadgetId;
            }


            if (Guid.TryParse(HttpContext.Current.Request.Form["gadgetId"], out gadgetId))
            {
                return gadgetId;
            }
            

            return Guid.Empty;
        }

        /// <summary>
        /// Empties the gadget cache.
        /// </summary>
        /// <param name="gadgetId">The gadget identifier.</param>
        public static void EmptyGadgetCache(Guid gadgetId)
        {
            string cacheKey = string.Format(CultureInfo.InvariantCulture, EPiServerNewrelicCacheKey, gadgetId);
            CacheManager.Remove(cacheKey);
        }

        /// <summary>
        /// Gets the server information.
        /// </summary>
        /// <param name="newRelicSettings">The new relic gadget settings.</param>
        /// <returns>Summary.</returns>
        public static ServerSummary GetServerInfo(NewRelicSettings newRelicSettings)
        {
            if (newRelicSettings == null)
            {
                return null;
            }

            string cacheKey = string.Format(CultureInfo.InvariantCulture, EPiServerNewrelicCacheKey, newRelicSettings.GadgetId);
            
            ServerSummary serverSummary = CacheManager.Get(cacheKey) as ServerSummary;

            if (serverSummary != null)
            {
                return serverSummary;
            }

            try
            {
                WebRequest webRequest =
                    WebRequest.Create(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "https://api.newrelic.com/v2/servers/{0}.json",
                            newRelicSettings.MachineId));

                webRequest.ContentType = "application/json";
                webRequest.Method = "GET";
                webRequest.Headers.Add(
                    string.Format(CultureInfo.InvariantCulture, "X-Api-Key:{0}", newRelicSettings.ApiKey));

                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        if (stream == null)
                        {
                            return null;
                        }

                        StreamReader reader = new StreamReader(stream);

                        string json = reader.ReadToEnd();
                        dynamic token = JObject.Parse(json);

                        serverSummary = new ServerSummary
                                              {
                                                  Cpu = token.server.summary.cpu,
                                                  CpuStolen = token.server.summary.cpu_stolen,
                                                  DiskIo = token.server.summary.disk_io,
                                                  FullestDisk = token.server.summary.fullest_disk,
                                                  FullestDiskFree = token.server.summary.fullest_disk_free,
                                                  Memory = token.server.summary.memory,
                                                  MemoryTotal = token.server.summary.memory_total,
                                                  MemoryUsed = token.server.summary.memory_used,
                                                  ServerName = token.server.name,
                                                  HostName = token.server.host
                                              };

                        CacheManager.Insert(cacheKey, serverSummary, new CacheEvictionPolicy(TimeSpan.FromSeconds(1800), CacheTimeoutType.Absolute));

                        return serverSummary;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error("[New Relic] Error getting data.", exception);
                return null ;
            }
        }

        #endregion
    }
}