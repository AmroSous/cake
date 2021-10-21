﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Cake.Common.IO;
using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Build;
using Cake.Common.Tools.DotNet.Clean;
using Cake.Common.Tools.DotNet.Execute;
using Cake.Common.Tools.DotNet.MSBuild;
using Cake.Common.Tools.DotNet.Restore;
using Cake.Common.Tools.DotNet.Run;
using Cake.Common.Tools.DotNet.Tool;
using Cake.Common.Tools.DotNetCore.Build;
using Cake.Common.Tools.DotNetCore.BuildServer;
using Cake.Common.Tools.DotNetCore.Clean;
using Cake.Common.Tools.DotNetCore.Execute;
using Cake.Common.Tools.DotNetCore.MSBuild;
using Cake.Common.Tools.DotNetCore.NuGet.Delete;
using Cake.Common.Tools.DotNetCore.NuGet.Push;
using Cake.Common.Tools.DotNetCore.NuGet.Source;
using Cake.Common.Tools.DotNetCore.Pack;
using Cake.Common.Tools.DotNetCore.Publish;
using Cake.Common.Tools.DotNetCore.Restore;
using Cake.Common.Tools.DotNetCore.Run;
using Cake.Common.Tools.DotNetCore.Test;
using Cake.Common.Tools.DotNetCore.Tool;
using Cake.Common.Tools.DotNetCore.VSTest;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Common.Tools.DotNetCore
{
    /// <summary>
    /// <para>Contains functionality related to <see href="https://github.com/dotnet/cli">.NET Core CLI</see>.</para>
    /// <para>
    /// In order to use the commands for this alias, the .Net Core CLI tools will need to be installed on the machine where
    /// the Cake script is being executed.  See this <see href="https://www.microsoft.com/net/core">page</see> for information
    /// on how to install.
    /// </para>
    /// </summary>
    [CakeAliasCategory("DotNetCore")]
    public static class DotNetCoreAliases
    {
        /// <summary>
        /// [deprecated] DotNetCoreExecute is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetExecute(ICakeContext, FilePath)" /> instead.
        /// Execute an assembly.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="assemblyPath">The assembly path.</param>
        /// <example>
        /// <code>
        /// DotNetCoreExecute("./bin/Debug/app.dll");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Execute")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Execute")]
        [Obsolete("DotNetCoreExecute is obsolete and will be removed in a future release. Use DotNetExecute instead.")]
        public static void DotNetCoreExecute(this ICakeContext context, FilePath assemblyPath)
        {
            context.DotNetExecute(assemblyPath);
        }

        /// <summary>
        /// [deprecated] DotNetCoreExecute is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetExecute(ICakeContext, FilePath, ProcessArgumentBuilder)" /> instead.
        /// Execute an assembly with arguments in the specific path.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="assemblyPath">The assembly path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <example>
        /// <code>
        /// DotNetCoreExecute("./bin/Debug/app.dll", "--arg");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Execute")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Execute")]
        [Obsolete("DotNetCoreExecute is obsolete and will be removed in a future release. Use DotNetExecute instead.")]
        public static void DotNetCoreExecute(this ICakeContext context, FilePath assemblyPath, ProcessArgumentBuilder arguments)
        {
            context.DotNetExecute(assemblyPath, arguments);
        }

        /// <summary>
        /// [deprecated] DotNetCoreExecute is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetExecute(ICakeContext, FilePath, ProcessArgumentBuilder, DotNetExecuteSettings)" /> instead.
        /// Execute an assembly with arguments in the specific path with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="assemblyPath">The assembly path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreExecuteSettings
        /// {
        ///     FrameworkVersion = "1.0.3"
        /// };
        ///
        /// DotNetCoreExecute("./bin/Debug/app.dll", "--arg", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Execute")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Execute")]
        [Obsolete("DotNetCoreExecute is obsolete and will be removed in a future release. Use DotNetExecute instead.")]
        public static void DotNetCoreExecute(this ICakeContext context, FilePath assemblyPath, ProcessArgumentBuilder arguments, DotNetCoreExecuteSettings settings)
        {
            context.DotNetExecute(assemblyPath, arguments, settings);
        }

        /// <summary>
        /// [deprecated] DotNetCoreRestore is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetRestore(ICakeContext)" /> instead.
        /// Restore all NuGet Packages.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// DotNetCoreRestore();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Restore")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Restore")]
        [Obsolete("DotNetCoreRestore is obsolete and will be removed in a future release. Use DotNetRestore instead.")]
        public static void DotNetCoreRestore(this ICakeContext context)
        {
            context.DotNetRestore();
        }

        /// <summary>
        /// [deprecated] DotNetCoreRestore is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetRestore(ICakeContext, string)" /> instead.
        /// Restore all NuGet Packages in the specified path.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="root">List of projects and project folders to restore. Each value can be: a path to a project.json or global.json file, or a folder to recursively search for project.json files.</param>
        /// <example>
        /// <code>
        /// DotNetCoreRestore("./src/*");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Restore")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Restore")]
        [Obsolete("DotNetCoreRestore is obsolete and will be removed in a future release. Use DotNetRestore instead.")]
        public static void DotNetCoreRestore(this ICakeContext context, string root)
        {
            context.DotNetRestore(root);
        }

        /// <summary>
        /// [deprecated] DotNetCoreRestore is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetRestore(ICakeContext, DotNetRestoreSettings)" /> instead.
        /// Restore all NuGet Packages with the settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreRestoreSettings
        /// {
        ///     Sources = new[] {"https://www.example.com/nugetfeed", "https://www.example.com/nugetfeed2"},
        ///     FallbackSources = new[] {"https://www.example.com/fallbacknugetfeed"},
        ///     PackagesDirectory = "./packages",
        ///     Verbosity = Information,
        ///     DisableParallel = true,
        ///     InferRuntimes = new[] {"runtime1", "runtime2"}
        /// };
        ///
        /// DotNetCoreRestore(settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Restore")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Restore")]
        [Obsolete("DotNetCoreRestore is obsolete and will be removed in a future release. Use DotNetRestore instead.")]
        public static void DotNetCoreRestore(this ICakeContext context, DotNetCoreRestoreSettings settings)
        {
            context.DotNetRestore(settings);
        }

        /// <summary>
        /// [deprecated] DotNetCoreRestore is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetRestore(ICakeContext, string, DotNetRestoreSettings)" /> instead.
        /// Restore all NuGet Packages in the specified path with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="root">List of projects and project folders to restore. Each value can be: a path to a project.json or global.json file, or a folder to recursively search for project.json files.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreRestoreSettings
        /// {
        ///     Sources = new[] {"https://www.example.com/nugetfeed", "https://www.example.com/nugetfeed2"},
        ///     FallbackSources = new[] {"https://www.example.com/fallbacknugetfeed"},
        ///     PackagesDirectory = "./packages",
        ///     Verbosity = Information,
        ///     DisableParallel = true,
        ///     InferRuntimes = new[] {"runtime1", "runtime2"}
        /// };
        ///
        /// DotNetCoreRestore("./src/*", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Restore")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Restore")]
        [Obsolete("DotNetCoreRestore is obsolete and will be removed in a future release. Use DotNetRestore instead.")]
        public static void DotNetCoreRestore(this ICakeContext context, string root, DotNetCoreRestoreSettings settings)
        {
            context.DotNetRestore(root, settings);
        }

        /// <summary>
        /// [deprecated] DotNetCoreBuild is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetBuild(ICakeContext, string)" /> instead.
        /// Build all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The projects path.</param>
        /// <example>
        /// <code>
        /// DotNetCoreBuild("./src/*");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Build")]
        [Obsolete("DotNetCoreBuild is obsolete and will be removed in a future release. Use DotNetBuild instead.")]
        public static void DotNetCoreBuild(this ICakeContext context, string project)
        {
            context.DotNetBuild(project);
        }

        /// <summary>
        /// [deprecated] DotNetCoreBuild is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetBuild(ICakeContext, string, DotNetBuildSettings)" /> instead.
        /// Build all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The projects path.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreBuildSettings
        /// {
        ///     Framework = "netcoreapp3.1",
        ///     Configuration = "Debug",
        ///     OutputDirectory = "./artifacts/"
        /// };
        ///
        /// DotNetCoreBuild("./src/*", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Build")]
        [Obsolete("DotNetCoreBuild is obsolete and will be removed in a future release. Use DotNetBuild instead.")]
        public static void DotNetCoreBuild(this ICakeContext context, string project, DotNetCoreBuildSettings settings)
        {
            context.DotNetBuild(project, settings);
        }

        /// <summary>
        /// Package all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The projects path.</param>
        /// <example>
        /// <code>
        /// DotNetCorePack("./src/*");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Pack")]
        public static void DotNetCorePack(this ICakeContext context, string project)
        {
            context.DotNetCorePack(project, null);
        }

        /// <summary>
        /// Package all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The projects path.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCorePackSettings
        /// {
        ///     Configuration = "Release",
        ///     OutputDirectory = "./artifacts/"
        /// };
        ///
        /// DotNetCorePack("./src/*", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Pack")]
        public static void DotNetCorePack(this ICakeContext context, string project, DotNetCorePackSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCorePackSettings();
            }

            var packer = new DotNetCorePacker(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            packer.Pack(project, settings);
        }

        /// <summary>
        /// [deprecated] DotNetCoreRun is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetRun(ICakeContext)" /> instead.
        /// Run all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// DotNetCoreRun();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Run")]
        [Obsolete("DotNetCoreRun is obsolete and will be removed in a future release. Use DotNetRun instead.")]
        public static void DotNetCoreRun(this ICakeContext context)
        {
            context.DotNetRun();
        }

        /// <summary>
        /// [deprecated] DotNetCoreRun is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetRun(ICakeContext, string)" /> instead.
        /// Run project.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <example>
        /// <code>
        /// DotNetCoreRun("./src/Project");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Run")]
        [Obsolete("DotNetCoreRun is obsolete and will be removed in a future release. Use DotNetRun instead.")]
        public static void DotNetCoreRun(this ICakeContext context, string project)
        {
            context.DotNetRun(project);
        }

        /// <summary>
        /// [deprecated] DotNetCoreRun is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetRun(ICakeContext, string, ProcessArgumentBuilder)" /> instead.
        /// Run project with path and arguments.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <example>
        /// <code>
        /// DotNetCoreRun("./src/Project", "--args");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Run")]
        [Obsolete("DotNetCoreRun is obsolete and will be removed in a future release. Use DotNetRun instead.")]
        public static void DotNetCoreRun(this ICakeContext context, string project, ProcessArgumentBuilder arguments)
        {
            context.DotNetRun(project, arguments);
        }

        /// <summary>
        /// [deprecated] DotNetCoreRun is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetRun(ICakeContext, string, ProcessArgumentBuilder, DotNetRunSettings)" /> instead.
        /// Run project with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreRunSettings
        /// {
        ///     Framework = "netcoreapp3.1",
        ///     Configuration = "Release"
        /// };
        ///
        /// DotNetCoreRun("./src/Project", "--args", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Run")]
        [Obsolete("DotNetCoreRun is obsolete and will be removed in a future release. Use DotNetRun instead.")]
        public static void DotNetCoreRun(this ICakeContext context, string project, ProcessArgumentBuilder arguments, DotNetCoreRunSettings settings)
        {
            context.DotNetRun(project, arguments, settings);
        }

        /// <summary>
        /// [deprecated] DotNetCoreRun is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetRun(ICakeContext, string, DotNetRunSettings)" /> instead.
        /// Run project with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreRunSettings
        /// {
        ///     Framework = "netcoreapp2.0",
        ///     Configuration = "Release"
        /// };
        ///
        /// DotNetCoreRun("./src/Project", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Run")]
        [Obsolete("DotNetCoreRun is obsolete and will be removed in a future release. Use DotNetRun instead.")]
        public static void DotNetCoreRun(this ICakeContext context, string project, DotNetCoreRunSettings settings)
        {
            context.DotNetRun(project, settings);
        }

        /// <summary>
        /// Publish all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The projects path.</param>
        /// <example>
        /// <code>
        /// DotNetCorePublish("./src/*");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Publish")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Publish")]
        public static void DotNetCorePublish(this ICakeContext context, string project)
        {
            context.DotNetCorePublish(project, null);
        }

        /// <summary>
        /// Publish all projects.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The projects path.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCorePublishSettings
        /// {
        ///     Framework = "netcoreapp3.1",
        ///     Configuration = "Release",
        ///     OutputDirectory = "./artifacts/"
        /// };
        ///
        /// DotNetCorePublish("./src/*", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Publish")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Publish")]
        public static void DotNetCorePublish(this ICakeContext context, string project, DotNetCorePublishSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCorePublishSettings();
            }

            var publisher = new DotNetCorePublisher(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            publisher.Publish(project, settings);
        }

        /// <summary>
        /// Test project.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// DotNetCoreTest();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Test")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Test")]
        public static void DotNetCoreTest(this ICakeContext context)
        {
            context.DotNetCoreTest(null, null, null);
        }

        /// <summary>
        /// Test project with path.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <example>
        /// <para>Specify the path to the .csproj file in the test project.</para>
        /// <code>
        /// DotNetCoreTest("./test/Project.Tests/Project.Tests.csproj");
        /// </code>
        /// <para>You could also specify a task that runs multiple test projects.</para>
        /// <para>Cake task:</para>
        /// <code>
        /// Task("Test")
        ///     .Does(() =>
        /// {
        ///     var projectFiles = GetFiles("./test/**/*.csproj");
        ///     foreach(var file in projectFiles)
        ///     {
        ///         DotNetCoreTest(file.FullPath);
        ///     }
        /// });
        /// </code>
        /// <para>If your test project is using project.json, the project parameter should just be the directory path.</para>
        /// <code>
        /// DotNetCoreTest("./test/Project.Tests/");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Test")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Test")]
        public static void DotNetCoreTest(this ICakeContext context, string project)
        {
            context.DotNetCoreTest(project, null, null);
        }

        /// <summary>
        /// Test project with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreTestSettings
        /// {
        ///     Configuration = "Release"
        /// };
        ///
        /// DotNetCoreTest("./test/Project.Tests/Project.Tests.csproj", settings);
        /// </code>
        /// <para>You could also specify a task that runs multiple test projects.</para>
        /// <para>Cake task:</para>
        /// <code>
        /// Task("Test")
        ///     .Does(() =>
        /// {
        ///     var settings = new DotNetCoreTestSettings
        ///     {
        ///         Configuration = "Release"
        ///     };
        ///
        ///     var projectFiles = GetFiles("./test/**/*.csproj");
        ///     foreach(var file in projectFiles)
        ///     {
        ///         DotNetCoreTest(file.FullPath, settings);
        ///     }
        /// });
        /// </code>
        /// <para>If your test project is using project.json, the project parameter should just be the directory path.</para>
        /// <code>
        /// var settings = new DotNetCoreTestSettings
        /// {
        ///     Configuration = "Release"
        /// };
        ///
        /// DotNetCoreTest("./test/Project.Tests/", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Test")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Test")]
        public static void DotNetCoreTest(this ICakeContext context, string project, DotNetCoreTestSettings settings)
        {
            context.DotNetCoreTest(project, null, settings);
        }

        /// <summary>
        /// Test project with settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreTestSettings
        /// {
        ///     Configuration = "Release"
        /// };
        ///
        /// DotNetCoreTest("./test/Project.Tests/Project.Tests.csproj", settings);
        /// </code>
        /// <para>You could also specify a task that runs multiple test projects.</para>
        /// <para>Cake task:</para>
        /// <code>
        /// Task("Test")
        ///     .Does(() =>
        /// {
        ///     var settings = new DotNetCoreTestSettings
        ///     {
        ///         Configuration = "Release"
        ///     };
        ///
        ///     var projectFiles = GetFiles("./test/**/*.csproj");
        ///     foreach(var file in projectFiles)
        ///     {
        ///         DotNetCoreTest(file.FullPath, "MSTest.MapInconclusiveToFailed=true", settings);
        ///     }
        /// });
        /// </code>
        /// <para>If your test project is using project.json, the project parameter should just be the directory path.</para>
        /// <code>
        /// var settings = new DotNetCoreTestSettings
        /// {
        ///     Configuration = "Release"
        /// };
        ///
        /// DotNetCoreTest("./test/Project.Tests/", "MSTest.MapInconclusiveToFailed=true", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Test")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Test")]
        public static void DotNetCoreTest(this ICakeContext context, string project, ProcessArgumentBuilder arguments, DotNetCoreTestSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreTestSettings();
            }

            var tester = new DotNetCoreTester(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            tester.Test(project, arguments, settings);
        }

        /// <summary>
        /// [deprecated] DotNetCoreClean is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetClean(ICakeContext, string)" /> instead.
        /// Cleans a project's output.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The project's path.</param>
        /// <example>
        /// <code>
        /// DotNetCoreClean("./src/project");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Clean")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Clean")]
        [Obsolete("DotNetCoreClean is obsolete and will be removed in a future release. Use DotNetClean instead.")]
        public static void DotNetCoreClean(this ICakeContext context, string project)
        {
            context.DotNetClean(project);
        }

        /// <summary>
        /// [deprecated] DotNetCoreClean is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetClean(ICakeContext, string, DotNetCleanSettings)" /> instead.
        /// Cleans a project's output.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="project">The projects path.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreCleanSettings
        /// {
        ///     Framework = "netcoreapp3.1",
        ///     Configuration = "Debug",
        ///     OutputDirectory = "./artifacts/"
        /// };
        ///
        /// DotNetCoreClean("./src/project", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Clean")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Clean")]
        [Obsolete("DotNetCoreClean is obsolete and will be removed in a future release. Use DotNetClean instead.")]
        public static void DotNetCoreClean(this ICakeContext context, string project, DotNetCoreCleanSettings settings)
        {
            context.DotNetClean(project, settings);
        }

        /// <summary>
        /// Delete a NuGet Package from a server.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// DotNetCoreNuGetDelete();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Delete")]
        public static void DotNetCoreNuGetDelete(this ICakeContext context)
        {
            context.DotNetCoreNuGetDelete(null, null, null);
        }

        /// <summary>
        /// Deletes a package from nuget.org.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageName">Name of package to delete.</param>
        /// <example>
        /// <code>
        /// DotNetCoreNuGetDelete("Microsoft.AspNetCore.Mvc");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Delete")]
        public static void DotNetCoreNuGetDelete(this ICakeContext context, string packageName)
        {
            context.DotNetCoreNuGetDelete(packageName, null, null);
        }

        /// <summary>
        /// Deletes a specific version of a package from nuget.org.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageName">Name of package to delete.</param>
        /// <param name="packageVersion">Version of package to delete.</param>
        /// <example>
        /// <code>
        /// DotNetCoreRestore("Microsoft.AspNetCore.Mvc", "1.0");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Delete")]
        public static void DotNetCoreNuGetDelete(this ICakeContext context, string packageName, string packageVersion)
        {
            context.DotNetCoreNuGetDelete(packageName, packageVersion, null);
        }

        /// <summary>
        /// Deletes a package from a server.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageName">Name of package to delete.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreNuGetDeleteSettings
        /// {
        ///     Source = "https://www.example.com/nugetfeed",
        ///     NonInteractive = true
        /// };
        ///
        /// DotNetCoreNuGetDelete("Microsoft.AspNetCore.Mvc", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Delete")]
        public static void DotNetCoreNuGetDelete(this ICakeContext context, string packageName, DotNetCoreNuGetDeleteSettings settings)
        {
            context.DotNetCoreNuGetDelete(packageName, null, settings);
        }

        /// <summary>
        /// Deletes a package from a server using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreNuGetDeleteSettings
        /// {
        ///     Source = "https://www.example.com/nugetfeed",
        ///     NonInteractive = true
        /// };
        ///
        /// DotNetCoreNuGetDelete(settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Delete")]
        public static void DotNetCoreNuGetDelete(this ICakeContext context, DotNetCoreNuGetDeleteSettings settings)
        {
            context.DotNetCoreNuGetDelete(null, null, settings);
        }

        /// <summary>
        /// Deletes a package from a server using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageName">Name of package to delete.</param>
        /// <param name="packageVersion">Version of package to delete.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreNuGetDeleteSettings
        /// {
        ///     Source = "https://www.example.com/nugetfeed",
        ///     NonInteractive = true
        /// };
        ///
        /// DotNetCoreNuGetDelete("Microsoft.AspNetCore.Mvc", "1.0", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Delete")]
        public static void DotNetCoreNuGetDelete(this ICakeContext context, string packageName, string packageVersion, DotNetCoreNuGetDeleteSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreNuGetDeleteSettings();
            }

            var nugetDeleter = new DotNetCoreNuGetDeleter(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            nugetDeleter.Delete(packageName, packageVersion, settings);
        }

        /// <summary>
        /// Pushes one or more packages to a server.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageFilePath"><see cref="FilePath"/> of the package to push.</param>
        /// <example>
        /// <code>
        /// // With FilePath instance
        /// var packageFilePath = GetFiles("*.nupkg").Single();
        /// DotNetCoreNuGetPush(packageFilePath);
        /// // With string parameter
        /// DotNetCoreNuGetPush("foo*.nupkg");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Push")]
        public static void DotNetCoreNuGetPush(this ICakeContext context, FilePath packageFilePath)
        {
            context.DotNetCoreNuGetPush(packageFilePath, null);
        }

        /// <summary>
        /// Pushes one or more packages to a server using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageFilePath"><see cref="FilePath"/> of the package to push.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreNuGetPushSettings
        /// {
        ///     Source = "https://www.example.com/nugetfeed",
        ///     ApiKey = "4003d786-cc37-4004-bfdf-c4f3e8ef9b3a"
        /// };
        /// // With FilePath instance
        /// var packageFilePath = GetFiles("foo*.nupkg").Single();
        /// DotNetCoreNuGetPush(packageFilePath);
        /// // With string parameter
        /// DotNetCoreNuGetPush("foo*.nupkg", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Push")]
        public static void DotNetCoreNuGetPush(this ICakeContext context, FilePath packageFilePath, DotNetCoreNuGetPushSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreNuGetPushSettings();
            }

            var restorer = new DotNetCoreNuGetPusher(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            restorer.Push(packageFilePath?.FullPath, settings);
        }

        /// <summary>
        /// Add the specified NuGet source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the source.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreNuGetSourceSettings
        /// {
        ///     Source = "https://www.example.com/nugetfeed",
        ///     UserName = "username",
        ///     Password = "password",
        ///     StorePasswordInClearText = true,
        ///     ValidAuthenticationTypes = "basic,negotiate"
        /// };
        ///
        /// DotNetCoreNuGetAddSource("example", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Source")]
        public static void DotNetCoreNuGetAddSource(this ICakeContext context, string name, DotNetCoreNuGetSourceSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var sourcer = new DotNetCoreNuGetSourcer(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            sourcer.AddSource(name, settings);
        }

        /// <summary>
        /// Disable the specified NuGet source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the source.</param>
        /// <example>
        /// <code>
        /// DotNetCoreNuGetDisableSource("example");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Source")]
        public static void DotNetCoreNuGetDisableSource(this ICakeContext context, string name)
        {
            context.DotNetCoreNuGetDisableSource(name, null);
        }

        /// <summary>
        /// Disable the specified NuGet source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the source.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreNuGetSourceSettings
        /// {
        ///     ConfigFile = "NuGet.config"
        /// };
        ///
        /// DotNetCoreNuGetDisableSource("example", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Source")]
        public static void DotNetCoreNuGetDisableSource(this ICakeContext context, string name, DotNetCoreNuGetSourceSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var sourcer = new DotNetCoreNuGetSourcer(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            sourcer.DisableSource(name, settings ?? new DotNetCoreNuGetSourceSettings());
        }

        /// <summary>
        /// Enable the specified NuGet source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the source.</param>
        /// <example>
        /// <code>
        /// DotNetCoreNuGetEnableSource("example");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Source")]
        public static void DotNetCoreNuGetEnableSource(this ICakeContext context, string name)
        {
            context.DotNetCoreNuGetEnableSource(name, null);
        }

        /// <summary>
        /// Enable the specified NuGet source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the source.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreNuGetSourceSettings
        /// {
        ///     ConfigFile = "NuGet.config"
        /// };
        ///
        /// DotNetCoreNuGetEnableSource("example", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Source")]
        public static void DotNetCoreNuGetEnableSource(this ICakeContext context, string name, DotNetCoreNuGetSourceSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var sourcer = new DotNetCoreNuGetSourcer(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            sourcer.EnableSource(name, settings ?? new DotNetCoreNuGetSourceSettings());
        }

        /// <summary>
        /// Determines whether the specified NuGet source exists.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the source.</param>
        /// <returns>Whether the specified NuGet source exists.</returns>
        /// <example>
        /// <code>
        /// var exists = DotNetCoreNuGetHasSource("example");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Source")]
        public static bool DotNetCoreNuGetHasSource(this ICakeContext context, string name)
        {
            return context.DotNetCoreNuGetHasSource(name, null);
        }

        /// <summary>
        /// Determines whether the specified NuGet source exists.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the source.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Whether the specified NuGet source exists.</returns>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreNuGetSourceSettings
        /// {
        ///     ConfigFile = "NuGet.config"
        /// };
        ///
        /// var exists = DotNetCoreNuGetHasSource("example", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Source")]
        public static bool DotNetCoreNuGetHasSource(this ICakeContext context, string name, DotNetCoreNuGetSourceSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var sourcer = new DotNetCoreNuGetSourcer(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            return sourcer.HasSource(name, settings ?? new DotNetCoreNuGetSourceSettings());
        }

        /// <summary>
        /// Remove the specified NuGet source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the source.</param>
        /// <example>
        /// <code>
        /// DotNetCoreNuGetRemoveSource("example");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Source")]
        public static void DotNetCoreNuGetRemoveSource(this ICakeContext context, string name)
        {
            context.DotNetCoreNuGetRemoveSource(name, null);
        }

        /// <summary>
        /// Remove the specified NuGet source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the source.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreNuGetSourceSettings
        /// {
        ///     ConfigFile = "NuGet.config"
        /// };
        ///
        /// DotNetCoreNuGetRemoveSource("example", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Source")]
        public static void DotNetCoreNuGetRemoveSource(this ICakeContext context, string name, DotNetCoreNuGetSourceSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var sourcer = new DotNetCoreNuGetSourcer(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            sourcer.RemoveSource(name, settings ?? new DotNetCoreNuGetSourceSettings());
        }

        /// <summary>
        /// Update the specified NuGet source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name of the source.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreNuGetSourceSettings
        /// {
        ///     Source = "https://www.example.com/nugetfeed",
        ///     UserName = "username",
        ///     Password = "password",
        ///     StorePasswordInClearText = true,
        ///     ValidAuthenticationTypes = "basic,negotiate"
        /// };
        ///
        /// DotNetCoreNuGetUpdateSource("example", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("NuGet")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.NuGet.Source")]
        public static void DotNetCoreNuGetUpdateSource(this ICakeContext context, string name, DotNetCoreNuGetSourceSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var sourcer = new DotNetCoreNuGetSourcer(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            sourcer.UpdateSource(name, settings);
        }

        /// <summary>
        /// [deprecated] DotNetCoreMSBuild is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetMSBuild(ICakeContext)" /> instead.
        /// Builds the specified targets in a project file found in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// DotNetCoreMSBuild();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MSBuild")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.MSBuild")]
        [Obsolete("DotNetCoreMSBuild is obsolete and will be removed in a future release. Use DotNetMSBuild instead.")]
        public static void DotNetCoreMSBuild(this ICakeContext context)
        {
            context.DotNetMSBuild();
        }

        /// <summary>
        /// [deprecated] DotNetCoreMSBuild is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetMSBuild(ICakeContext, string)" /> instead.
        /// Builds the specified targets in the project file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectOrDirectory">Project file or directory to search for project file.</param>
        /// <example>
        /// <code>
        /// DotNetCoreMSBuild("foobar.proj");
        /// </code>
        /// </example>
        /// <remarks>
        /// If a directory is specified, MSBuild searches that directory for a project file.
        /// </remarks>
        [CakeMethodAlias]
        [CakeAliasCategory("MSBuild")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.MSBuild")]
        [Obsolete("DotNetCoreMSBuild is obsolete and will be removed in a future release. Use DotNetMSBuild instead.")]
        public static void DotNetCoreMSBuild(this ICakeContext context, string projectOrDirectory)
        {
            context.DotNetMSBuild(projectOrDirectory);
        }

        /// <summary>
        /// [deprecated] DotNetCoreMSBuild is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetMSBuild(ICakeContext, DotNetMSBuildSettings)" /> instead.
        /// Builds the specified targets in a project file found in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreMSBuildSettings
        /// {
        ///     NoLogo = true,
        ///     MaxCpuCount = -1
        /// };
        ///
        /// DotNetCoreMSBuild(settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("MSBuild")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.MSBuild")]
        [Obsolete("DotNetCoreMSBuild is obsolete and will be removed in a future release. Use DotNetMSBuild instead.")]
        public static void DotNetCoreMSBuild(this ICakeContext context, DotNetCoreMSBuildSettings settings)
        {
            context.DotNetMSBuild(settings);
        }

        /// <summary>
        /// [deprecated] DotNetCoreMSBuild is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetMSBuild(ICakeContext, string, DotNetMSBuildSettings)" /> instead.
        /// Builds the specified targets in the project file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectOrDirectory">Project file or directory to search for project file.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreMSBuildSettings
        /// {
        ///     NoLogo = true,
        ///     MaxCpuCount = -1
        /// };
        ///
        /// DotNetCoreMSBuild("foobar.proj", settings);
        /// </code>
        /// </example>
        /// <remarks>
        /// If a project file is not specified, MSBuild searches the current working directory for a file that has a file
        /// extension that ends in "proj" and uses that file. If a directory is specified, MSBuild searches that directory for a project file.
        /// </remarks>
        [CakeMethodAlias]
        [CakeAliasCategory("MSBuild")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.MSBuild")]
        [Obsolete("DotNetCoreMSBuild is obsolete and will be removed in a future release. Use DotNetMSBuild instead.")]
        public static void DotNetCoreMSBuild(this ICakeContext context, string projectOrDirectory, DotNetCoreMSBuildSettings settings)
        {
            context.DotNetMSBuild(projectOrDirectory, settings);
        }

        /// <summary>
        /// Test one or more projects specified by a path or glob pattern using the VS Test host runner.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="testFile">A path to the test file or glob for one or more test files.</param>
        /// <example>
        /// <para>Specify the path to the .csproj file in the test project.</para>
        /// <code>
        /// DotNetCoreVSTest("./test/Project.Tests/bin/Release/netcoreapp2.1/Project.Tests.dll");
        /// </code>
        /// <para>You could also specify a glob pattern to run multiple test projects.</para>
        /// <code>
        /// DotNetCoreVSTest("./**/bin/Release/netcoreapp2.1/*.Tests.dll");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Test")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.VSTest")]
        public static void DotNetCoreVSTest(this ICakeContext context, GlobPattern testFile) => context.DotNetCoreVSTest(testFile, null);

        /// <summary>
        /// Test one or more projects specified by a path or glob pattern with settings using the VS Test host runner.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="testFile">A path to the test file or glob for one or more test files.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Specify the path to the .csproj file in the test project.</para>
        /// <code>
        /// var settings = new DotNetCoreVSTestSettings
        /// {
        ///     Framework = "FrameworkCore10",
        ///     Platform = "x64"
        /// };
        ///
        /// DotNetCoreTest("./test/Project.Tests/bin/Release/netcoreapp2.1/Project.Tests.dll", settings);
        /// </code>
        /// <para>You could also specify a glob pattern to run multiple test projects.</para>
        /// <code>
        /// var settings = new DotNetCoreVSTestSettings
        /// {
        ///     Framework = "FrameworkCore10",
        ///     Platform = "x64",
        ///     Parallel = true
        /// };
        ///
        /// DotNetCoreVSTest("./**/bin/Release/netcoreapp2.1/*.Tests.dll", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Test")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.VSTest")]
        public static void DotNetCoreVSTest(this ICakeContext context, GlobPattern testFile, DotNetCoreVSTestSettings settings)
        {
            var testFiles = context.GetFiles(testFile);

            context.DotNetCoreVSTest(testFiles, settings);
        }

        /// <summary>
        /// Test one or more specified projects with settings using the VS Test host runner.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="testFiles">The project paths to test.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreVSTestSettings
        /// {
        ///     Framework = "FrameworkCore10",
        ///     Platform = "x64"
        /// };
        ///
        /// DotNetCoreVSTest(new[] { (FilePath)"./test/Project.Tests/bin/Release/netcoreapp2.1/Project.Tests.dll" }, settings);
        /// </code>
        /// <para>You could also specify a task that runs multiple test projects.</para>
        /// <para>Cake task:</para>
        /// <code>
        /// Task("Test")
        ///     .Does(() =>
        /// {
        ///     var settings = new DotNetCoreVSTestSettings
        ///     {
        ///         Framework = "FrameworkCore10",
        ///         Platform = "x64",
        ///         Parallel = true
        ///     };
        ///
        ///     var testFiles = GetFiles("./test/**/bin/Release/netcoreapp2.1/*.Test.dll");
        ///
        ///     DotNetCoreVSTest(testFiles, settings);
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Test")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.VSTest")]
        public static void DotNetCoreVSTest(this ICakeContext context, IEnumerable<FilePath> testFiles, DotNetCoreVSTestSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                settings = new DotNetCoreVSTestSettings();
            }

            var tester = new DotNetCoreVSTester(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            tester.Test(testFiles, settings);
        }

        /// <summary>
        /// [deprecated] DotNetCoreTool is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetTool(ICakeContext, string)" /> instead.
        /// Execute an .NET Core Extensibility Tool.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="command">The command to execute.</param>
        /// <example>
        /// <code>
        /// DotNetCoreTool("cake");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Tool")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Tool")]
        [Obsolete("DotNetCoreTool is obsolete and will be removed in a future release. Use DotNetTool instead.")]
        public static void DotNetCoreTool(this ICakeContext context, string command)
        {
            context.DotNetTool(command);
        }

        /// <summary>
        /// [deprecated] DotNetCoreTool is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetTool(ICakeContext, string, DotNetToolSettings)" /> instead.
        /// Execute an .NET Core Extensibility Tool.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="command">The command to execute.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreToolSettings
        /// {
        ///     DiagnosticOutput = true
        /// };
        ///
        /// DotNetCoreTool("cake", settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Tool")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Tool")]
        [Obsolete("DotNetCoreTool is obsolete and will be removed in a future release. Use DotNetTool instead.")]
        public static void DotNetCoreTool(this ICakeContext context, string command, DotNetCoreToolSettings settings)
        {
            context.DotNetTool(command, settings);
        }

        /// <summary>
        /// [deprecated] DotNetCoreTool is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetTool(ICakeContext, FilePath, string)" /> instead.
        /// Execute an .NET Core Extensibility Tool.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectPath">The project path.</param>
        /// <param name="command">The command to execute.</param>
        /// <example>
        /// <code>
        /// DotNetCoreTool("./src/project", "xunit", "-xml report.xml");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Tool")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Tool")]
        [Obsolete("DotNetCoreTool is obsolete and will be removed in a future release. Use DotNetTool instead.")]
        public static void DotNetCoreTool(this ICakeContext context, FilePath projectPath, string command)
        {
            context.DotNetTool(projectPath, command);
        }

        /// <summary>
        /// [deprecated] DotNetCoreTool is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetTool(ICakeContext, FilePath, string, ProcessArgumentBuilder)" /> instead.
        /// Execute an .NET Core Extensibility Tool.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectPath">The project path.</param>
        /// <param name="command">The command to execute.</param>
        /// <param name="arguments">The arguments.</param>
        /// <example>
        /// <code>
        /// DotNetCoreTool("./src/project", "xunit", "-xml report.xml");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Tool")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Tool")]
        [Obsolete("DotNetCoreTool is obsolete and will be removed in a future release. Use DotNetTool instead.")]
        public static void DotNetCoreTool(this ICakeContext context, FilePath projectPath, string command, ProcessArgumentBuilder arguments)
        {
            context.DotNetTool(projectPath, command, arguments);
        }

        /// <summary>
        /// [deprecated] DotNetCoreTool is obsolete and will be removed in a future release. Use <see cref="DotNetAliases.DotNetTool(ICakeContext, FilePath, string, ProcessArgumentBuilder, DotNetToolSettings)" /> instead.
        /// Execute an .NET Core Extensibility Tool.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectPath">The project path.</param>
        /// <param name="command">The command to execute.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// DotNetCoreTool("./src/project", "xunit", "-xml report.xml");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Tool")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.Tool")]
        [Obsolete("DotNetCoreTool is obsolete and will be removed in a future release. Use DotNetTool instead.")]
        public static void DotNetCoreTool(this ICakeContext context, FilePath projectPath, string command, ProcessArgumentBuilder arguments, DotNetCoreToolSettings settings)
        {
            context.DotNetTool(projectPath, command, arguments, settings);
        }

        /// <summary>
        /// Shuts down build servers that are started from dotnet.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// DotNetCoreBuildServerShutdown();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build Server")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.BuildServer")]
        public static void DotNetCoreBuildServerShutdown(this ICakeContext context)
        {
            context.DotNetCoreBuildServerShutdown(null);
        }

        /// <summary>
        /// Shuts down build servers that are started from dotnet.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// var settings = new DotNetCoreBuildServerSettings
        /// {
        ///     MSBuild = true
        /// };
        ///
        /// DotNetCoreBuildServerShutdown(settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Build Server")]
        [CakeNamespaceImport("Cake.Common.Tools.DotNetCore.BuildServer")]
        public static void DotNetCoreBuildServerShutdown(this ICakeContext context, DotNetCoreBuildServerSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var buildServer = new DotNetCoreBuildServer(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);

            buildServer.Shutdown(settings ?? new DotNetCoreBuildServerSettings());
        }
    }
}