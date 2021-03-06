// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EPi.Gadgets.NewRelic.Models")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EPi.Gadgets.NewRelic.Controllers")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "EPi.Gadgets.NewRelic.Business")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Scope = "member", Target = "EPi.Gadgets.NewRelic.Business.Extensions.#GetStore`1(EPiServer.Data.Dynamic.DynamicDataStoreFactory)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "EPi.Gadgets.NewRelic.Business.Extensions.#GetStore`1(EPiServer.Data.Dynamic.DynamicDataStoreFactory)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings", Scope = "member", Target = "EPi.Gadgets.NewRelic.Business.Helpers.#GetServerInfo(EPi.Gadgets.NewRelic.Models.NewRelicSettings)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member", Target = "EPi.Gadgets.NewRelic.Business.Helpers.#GetServerInfo(EPi.Gadgets.NewRelic.Models.NewRelicSettings)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "EPi.Gadgets.NewRelic.Business.Helpers.#GetServerInfo(EPi.Gadgets.NewRelic.Models.NewRelicSettings)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Api", Scope = "member", Target = "EPi.Gadgets.NewRelic.Models.NewRelicSettings.#ApiKey")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "EPi.Gadgets.NewRelic.Controllers.NewRelicSettingsController.#SaveConfiguration(EPi.Gadgets.NewRelic.Models.NewRelicSettings)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cpu", Scope = "member", Target = "EPi.Gadgets.NewRelic.Models.ServerSummary.#Cpu")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cpu", Scope = "member", Target = "EPi.Gadgets.NewRelic.Models.ServerSummary.#CpuStolen")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Io", Scope = "member", Target = "EPi.Gadgets.NewRelic.Models.ServerSummary.#DiskIo")]
