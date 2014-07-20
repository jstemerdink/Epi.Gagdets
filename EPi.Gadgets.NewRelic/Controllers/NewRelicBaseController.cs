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

    using EPiServer.Shell.Gadgets;

    /// <summary>
    /// Class NewRelicBaseController.
    /// </summary>
    public class NewRelicBaseController : Controller
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Configures the settings.
        /// </summary>
        /// <param name="gadgetId">The gadget identifier.</param>
        /// <returns>ActionResult.</returns>
        [GadgetAction(ResourceType = typeof(Resources), TextResourceKey = "GadgetSettings")]
        public ActionResult ConfigureSettings(Guid gadgetId)
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary { { "gadgetId", gadgetId } };
            return this.RedirectToAction("Index", "NewRelicSettings", routeValueDictionary);
        }

        /// <summary>
        ///     Default view for the NewRelic Gadget.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [GadgetAction(ResourceType = typeof(Resources), TextResourceKey = "ServerStatus")]
        public ActionResult ShowServerStatus(Guid gadgetId)
        {
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary { { "gadgetId", gadgetId } };

            return this.RedirectToAction("Index", "NewRelicGadget", routeValueDictionary);
        }

        #endregion
    }
}