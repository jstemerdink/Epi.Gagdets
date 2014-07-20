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
    using System.Linq;

    using EPi.Gadgets.NewRelic.Models;

    using EPiServer.Data.Dynamic;

    /// <summary>
    /// The SettingsRepository class
    /// </summary>
    /// <examples>
    /// SettingsRepository singleton = SettingsRepository.Instance;
    /// </examples>
    public sealed class SettingsRepository
    {
        /// <summary>
        /// The synclock object.
        /// </summary>
        private static readonly object SyncLock = new object();

        /// <summary>
        /// The one and only SettingsRepository instance.
        /// </summary>
        private static volatile SettingsRepository instance;

        private readonly DynamicDataStoreFactory storeFactory;

        /// <summary>
        /// Prevents a default instance of the <see cref="SettingsRepository"/> class from being created.
        /// </summary>
        private SettingsRepository()
        {
            this.storeFactory = DynamicDataStoreFactory.Instance;
        }

        private DynamicDataStore GadgetStore
        {
            get
            {
                return this.storeFactory.GetStore<NewRelicSettings>();
            }
        }


        /// <summary>
        /// Gets the gadget settings.
        /// </summary>
        /// <param name="gadgetId">The gadget identifier.</param>
        /// <returns>NewRelicSettings.</returns>
        public NewRelicSettings GetGadgetSettings(Guid gadgetId)
        {

            return this.GadgetStore.Items<NewRelicSettings>().FirstOrDefault(gs => gs.GadgetId == gadgetId);
        }

        /// <summary>
        /// Saves the gadget settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void SaveGadgetSettings(NewRelicSettings settings)
        {
            // Save the settings.
            this.GadgetStore.Save(settings);
        }

        /// <summary>
        /// Gets the instance of the SettingsRepository object.
        /// </summary>
        public static SettingsRepository Instance
        {
            get
            {
                // Double checked locking
                if (instance != null)
                {
                    return instance;
                }

                lock (SyncLock)
                {
                    if (instance == null)
                    {
                        instance = new SettingsRepository();
                    }
                }

                return instance;
            }
        }
    }
}