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

namespace EPi.Gadgets.NewRelic.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using EPi.Gadgets.NewRelic.Business;
    using EPi.Gadgets.NewRelic.Models;

    using EPiServer.Shell.Gadgets;
    using EPiServer.Shell.Web;

    /// <summary>
    ///     Class NewRelicGadgetController.
    /// </summary>
    [ScriptResource("Scripts/NewRelicGadget.js")]
    [Gadget(ClientScriptInitMethod = "newrelicgadget.init",
        IconUrl = "data:image/jpg;base64,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",
        Category = "dashboard",
        ResourceType = typeof(Resources), 
        NameResourceKey = "GadgetTitle", 
        DescriptionResourceKey = "GadgetDescription")
    ]
    [Authorize(Roles = "CmsAdmins")]
    public class NewRelicGadgetController : NewRelicBaseController
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Default view for the NewRelic Gadget.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            Guid gadgetId = this.ControllerContext.GetGadgetId();

            NewRelicSettings settings = SettingsRepository.Instance.GetGadgetSettings(gadgetId);

            RouteValueDictionary routeValueDictionary = new RouteValueDictionary { { "gadgetId", gadgetId } };

            if (settings == null)
            {
                return this.RedirectToAction("Index", "NewRelicSettings", routeValueDictionary);
            }

            NewRelicGadgetModel newRelicGadgetModel = new NewRelicGadgetModel
                                                          {
                                                              ServerSummary =
                                                                  Helpers.GetServerInfo(settings)
                                                          };

            if (newRelicGadgetModel.ServerSummary == null)
            {
                return this.RedirectToAction("Index", "NewRelicSettings", routeValueDictionary);
            }

            return this.View(newRelicGadgetModel);
        }

        #endregion
    }
}