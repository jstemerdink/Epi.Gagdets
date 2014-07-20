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
    using System.Reflection;

    using EPiServer.Data.Cache;
    using EPiServer.Data.Dynamic;

    using log4net;

    /// <summary>
    ///     Class Extensions.
    /// </summary>
    public static class Extensions
    {
        #region Static Fields

        /// <summary>
        ///     Initializes the <see cref="LogManager">LogManager</see> for the <see cref="Extensions" /> class.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(Extensions));

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeFactory">The store factory.</param>
        /// <returns>DynamicDataStore.</returns>
        /// <exception cref="System.ArgumentNullException">storeFactory</exception>
        public static DynamicDataStore GetStore<T>(this DynamicDataStoreFactory storeFactory)
        {
            if (storeFactory == null)
            {
                throw new ArgumentNullException("storeFactory");
            }

            try
            {
                return storeFactory.GetStore(typeof(T)) ?? storeFactory.CreateStore(typeof(T));
            }
            catch (NullReferenceException nullReferenceException)
            {
                Log.Error("[New Relic] Error getting settings.", nullReferenceException);

                try
                {
                    DynamicDataStoreFactory.Instance.DeleteStore(typeof(T), true);

                    FieldInfo fieldInfo = DynamicDataStoreFactory.Instance.GetType()
                        .GetField("_storeCheckResults", BindingFlags.Instance | BindingFlags.NonPublic);

                    if (fieldInfo != null)
                    {
                        LocalCache<Type, Exception> localCache =
                            (LocalCache<Type, Exception>)fieldInfo.GetValue(DynamicDataStoreFactory.Instance);

                        if (localCache.ContainsKey(typeof(T)))
                        {
                            localCache.Remove(typeof(T));
                        }
                    }
                }
                catch (Exception exception)
                {
                    Log.Error("[New Relic] Error getting settings.", exception);
                }
            }

            return storeFactory.CreateStore(typeof(T));
        }
        
        #endregion
    }
}