﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using System.Diagnostics;
using System.IO;
using System.Reflection;
using Mosa.Compiler.Common.Configuration;
using Mosa.Compiler.Framework;

namespace Mosa.Utility.Launcher;

public class BaseLauncher
{
	public CompilerHooks CompilerHooks { get; }

	public LauncherSettings LauncherSettings { get; }

	public Settings Settings => LauncherSettings.Settings;

	public BaseLauncher(Settings settings, CompilerHooks compilerHook)
	{
		CompilerHooks = compilerHook;

		var startSettings = new Settings();

		SetDefaultSettings(startSettings);

		startSettings.Merge(settings);

		LauncherSettings = new LauncherSettings(startSettings);

		NormalizeSettings();

		SetDefaults();
	}

	private void SetDefaultSettings(Settings settings)
	{
		settings.SetValue("Emulator", "Qemu");
		settings.SetValue("Emulator.Memory", 128);
		settings.SetValue("Emulator.Cores", 1);

		//settings.SetValue("Emulator.Serial", "none");
		settings.SetValue("Emulator.Serial.Host", "127.0.0.1");
		settings.SetValue("Emulator.Serial.Port", 9999);
		settings.SetValue("Emulator.Serial.Pipe", "MOSA");
		settings.SetValue("Launcher.PlugKorlib", true);
	}

	protected void NormalizeSettings()
	{
		// Normalize inputs
		LauncherSettings.ImageFormat = LauncherSettings.ImageFormat == null ? string.Empty : LauncherSettings.ImageFormat.ToLowerInvariant().Trim();
		LauncherSettings.FileSystem = LauncherSettings.FileSystem == null ? string.Empty : LauncherSettings.FileSystem.ToLowerInvariant().Trim();
		LauncherSettings.EmulatorSerial = LauncherSettings.EmulatorSerial == null ? string.Empty : LauncherSettings.EmulatorSerial.ToLowerInvariant().Trim();
		LauncherSettings.Emulator = LauncherSettings.Emulator == null ? string.Empty : LauncherSettings.Emulator.ToLowerInvariant().Trim();
		LauncherSettings.Platform = LauncherSettings.Platform.ToLowerInvariant().Trim();
	}

	private void SetDefaults()
	{
		if (string.IsNullOrWhiteSpace(LauncherSettings.TemporaryFolder) || LauncherSettings.TemporaryFolder != "%DEFAULT%")
		{
			LauncherSettings.TemporaryFolder = Path.Combine(Path.GetTempPath(), "MOSA");
		}

		if (string.IsNullOrWhiteSpace(LauncherSettings.DefaultFolder) || LauncherSettings.DefaultFolder != "%DEFAULT%")
		{
			if (LauncherSettings.OutputFile != null && LauncherSettings.OutputFile != "%DEFAULT%")
			{
				LauncherSettings.DefaultFolder = Path.GetDirectoryName(Path.GetFullPath(LauncherSettings.OutputFile));
			}
			else
			{
				LauncherSettings.DefaultFolder = LauncherSettings.TemporaryFolder;
			}
		}

		if (LauncherSettings.ImageFolder != null && LauncherSettings.ImageFolder != "%DEFAULT%")
		{
			LauncherSettings.ImageFolder = LauncherSettings.DefaultFolder;
		}

		string baseFilename;

		if (LauncherSettings.OutputFile != null && LauncherSettings.OutputFile != "%DEFAULT%")
		{
			baseFilename = Path.GetFileNameWithoutExtension(LauncherSettings.OutputFile);
		}
		else if (LauncherSettings.SourceFiles != null && LauncherSettings.SourceFiles.Count != 0)
		{
			baseFilename = Path.GetFileNameWithoutExtension(LauncherSettings.SourceFiles[0]);
		}
		else if (LauncherSettings.ImageFile != null && LauncherSettings.ImageFile != "%DEFAULT%")
		{
			baseFilename = Path.GetFileNameWithoutExtension(LauncherSettings.ImageFile);
		}
		else
		{
			baseFilename = "_mosa_";
		}

		var defaultFolder = LauncherSettings.DefaultFolder;

		if (LauncherSettings.OutputFile is null or "%DEFAULT%")
		{
			LauncherSettings.OutputFile = Path.Combine(defaultFolder, $"{baseFilename}.bin");
		}

		if (LauncherSettings.ImageFile == "%DEFAULT%")
		{
			LauncherSettings.ImageFile = Path.Combine(LauncherSettings.ImageFolder, $"{baseFilename}.{LauncherSettings.ImageFormat}");
		}

		if (LauncherSettings.MapFile == "%DEFAULT%")
		{
			LauncherSettings.MapFile = Path.Combine(defaultFolder, $"{baseFilename}-map.txt");
		}

		if (LauncherSettings.CompileTimeFile == "%DEFAULT%")
		{
			LauncherSettings.CompileTimeFile = Path.Combine(defaultFolder, $"{baseFilename}-time.txt");
		}

		if (LauncherSettings.DebugFile == "%DEFAULT%")
		{
			LauncherSettings.DebugFile = Path.Combine(defaultFolder, $"{baseFilename}.debug");
		}

		if (LauncherSettings.InlinedFile == "%DEFAULT%")
		{
			LauncherSettings.InlinedFile = Path.Combine(defaultFolder, $"{baseFilename}-inlined.txt");
		}

		if (LauncherSettings.PreLinkHashFile == "%DEFAULT%")
		{
			LauncherSettings.PreLinkHashFile = Path.Combine(defaultFolder, $"{baseFilename}-prelink-hash.txt");
		}

		if (LauncherSettings.PostLinkHashFile == "%DEFAULT%")
		{
			LauncherSettings.PostLinkHashFile = Path.Combine(defaultFolder, $"{baseFilename}-postlink-hash.txt");
		}

		if (LauncherSettings.AsmFile == "%DEFAULT%")
		{
			LauncherSettings.AsmFile = Path.Combine(defaultFolder, $"{baseFilename}.asm");
		}

		if (LauncherSettings.NasmFile == "%DEFAULT%")
		{
			LauncherSettings.NasmFile = Path.Combine(defaultFolder, $"{baseFilename}.nasm");
		}
	}

	protected void Output(string status)
	{
		if (status == null)
			return;

		OutputEvent(status);
	}

	protected virtual void OutputEvent(string status)
	{
		CompilerHooks.NotifyStatus?.Invoke(status);
	}

	protected static byte[] GetResource(string path, string name)
	{
		var newname = path.Replace(".", "._").Replace(@"\", "._").Replace("/", "._").Replace("-", "_") + "." + name;
		return GetResource(newname);
	}

	protected static byte[] GetResource(string name)
	{
		var assembly = Assembly.GetExecutingAssembly();
		var stream = assembly.GetManifestResourceStream("Mosa.Utility.Launcher.Resources." + name);
		var binary = new BinaryReader(stream);
		return binary.ReadBytes((int)stream.Length);
	}

	protected static string Quote(string location)
	{
		return '"' + location + '"';
	}

	protected ExternalProcess LaunchApplicationEx(string app, string args, bool captureOutput = false)
	{
		Output($"Launching Application: {app}");
		Output($"Arguments: {args}");

		var externalProcess = new ExternalProcess(app, args, captureOutput);

		externalProcess.Start();

		return externalProcess;
	}

	protected Process LaunchApplication(string app, string args)
	{
		Output($"Launching Application: {app}");
		Output($"Arguments: {args}");

		var start = new ProcessStartInfo
		{
			FileName = app,
			Arguments = args,
			UseShellExecute = false,
			CreateNoWindow = true,
			RedirectStandardOutput = true,
			RedirectStandardError = true
		};

		return Process.Start(start);
	}

	protected Process LaunchConsoleApplication(string app, string args)
	{
		Output($"Launching Console Application: {app}");
		Output($"Arguments: {args}");

		var start = new ProcessStartInfo
		{
			FileName = app,
			Arguments = args,
			UseShellExecute = false,
			CreateNoWindow = false,
			RedirectStandardOutput = false,
			RedirectStandardError = false
		};

		return Process.Start(start);
	}

	protected string GetOutput(Process process)
	{
		var output = process.StandardOutput.ReadToEnd();

		process.WaitForExit();

		var error = process.StandardError.ReadToEnd();

		return output + error;
	}

	protected Process LaunchApplicationWithOutput(string app, string arg)
	{
		var process = LaunchApplication(app, arg);

		var output = GetOutput(process);
		Output(output);

		return process;
	}

	protected string NullToEmpty(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
			return string.Empty;

		return value;
	}
}
