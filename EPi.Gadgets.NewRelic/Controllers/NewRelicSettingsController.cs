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

    /// <summary>
    /// Class NewRelicSettingsController.
    /// </summary>
    [Authorize(Roles = "CmsAdmins")]
    ////[VerifyGadgetOwner] 
    public class NewRelicSettingsController : NewRelicBaseController
    {
        #region Public Methods and Operators

        /// <summary>
        /// Displays the settings, if any.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            Guid gadgetId = this.ControllerContext.GetGadgetId();

            NewRelicSettings settings = SettingsRepository.Instance.GetGadgetSettings(gadgetId);

            return this.View(settings);
        }

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>ActionResult.</returns>
        [ValidateInput(true)]
        public ActionResult SaveConfiguration(NewRelicSettings settings)
        {
            if (this.ModelState.IsValid)
            {
                SettingsRepository.Instance.SaveGadgetSettings(settings);
                Helpers.EmptyGadgetCache(settings.GadgetId);
            }

            RouteValueDictionary routeValueDictionary = new RouteValueDictionary { { "gadgetId", settings.GadgetId } };

            return this.RedirectToAction("Index", routeValueDictionary);
        }

        #endregion
    }
}