﻿namespace Minary
{
  using System;
  using System.IO;
  using System.Security.Principal;


  public partial class Config
  {

    #region MEMBERS

    public static readonly string DebuggingFile = "DEBUG.txt";
    public static readonly string LogFile = "Logfile.txt";

    public static readonly string ApplicationName = "Minary";

    //// TODO : Candidates to export the app.config file
    public static readonly string MinaryVersion = "1.0.0";
public static readonly string CurrentVersionURL = "http://buglist.io/download/currentVersion.xml";
public static readonly string ToolHomepage = "http://www.buglist.io/downloads.php";

    public static readonly string PipeName = "Minary";
    public static readonly string MinaryFileExtension = "mry";
    public static readonly int PipeInstances = 16;

    //// TODO : This are all candidates to export the app.config file


    public static readonly string PluginsDir = "plugins";
    public static readonly string TemplatesDir = "templates";
    public static readonly string CustomTemplatesDir = Path.Combine(TemplatesDir, "MyTemplates");

//// public static readonly string BinaryDir = "bin";
    public static readonly string MinaryDllDir = "dll";
////    public static readonly string SessionDir = "sessions";
    public static readonly string PatternDir = "patterns";
    public static readonly string DataDir = "data";

// public static string LocalBinariesPath { get { return (Path.Combine(Directory.GetCurrentDirectory(), Config.BinaryDir)); } }
// public static string LocalPluginPath { get { return (Path.Combine(Directory.GetCurrentDirectory(), Config.PluginsDir)); } }

    // Services
    public static readonly string AttackServicesDir = "attackservices";


    // Service: APE
    public static readonly string ApeServiceDir = Path.Combine(AttackServicesDir, "APE");
    public static readonly string ApeBinaryPath = Path.Combine(ApeServiceDir, "Ape.exe");
    public static readonly string ApeProcessName = "Ape";

public static readonly string ApeFirewallRules = ".fwrules";
public static readonly string ApeTargetHosts = ".targethosts";
public static readonly string DnsPoisoningHosts = ".dnshosts";

// Service: ApeSniffer
public static readonly string ApeSnifferServiceDir = Path.Combine(AttackServicesDir, "ApeSniffer");
public static readonly string ApeSnifferBinaryPath = Path.Combine(ApeSnifferServiceDir, "ApeSniffer.exe");
public static readonly string ApeSnifferProcessName = "ApeSniffer";

// Service: ArpScan
public static readonly string ArpScanServiceDir = Path.Combine(AttackServicesDir, "ArpScan");
public static readonly string ArpScanBinaryPath = Path.Combine(ArpScanServiceDir, "ArpScan.exe");
public static readonly string ArpScanProcessName = "ArpScan";

// Service: HttpReverseProxy
public static readonly string HttpReverseProxyServiceDir = Path.Combine(AttackServicesDir, "HttpReverseProxy");
public static readonly string HttpReverseProxyBinaryPath = Path.Combine(HttpReverseProxyServiceDir, "HttpReverseProxy.exe");
public static readonly string HttpReverseProxyConfigFilePath = Path.Combine(HttpReverseProxyServiceDir, "plugin.config");
public static readonly string HttpReverseProxyName = "HttpReverseProxy";
public static readonly string HttpReverseProxyCertrifcateDir = Path.Combine(HttpReverseProxyServiceDir, "Certificates");
// public static string HttpReverseProxyPath { get { return (Path.Combine(Directory.GetCurrentDirectory(), Config.BinaryDir, Config.HttpReverseProxyBinaryPath)); } }

// Service: HttpReverseProxy/SslStrip
public static readonly string SslStripDir = Path.Combine(HttpReverseProxyServiceDir, @"plugins\SslStrip");
public static readonly string SslStripConfigFilePath = Path.Combine(SslStripDir, "plugin.config");

// Service: HttpReverseProxy/DataSniffer
public static readonly string DataSnifferDir = Path.Combine(HttpReverseProxyServiceDir, @"plugins\DataSniffer");
public static readonly string DataSnifferConfigFilePath = Path.Combine(DataSnifferDir, "plugin.config");

// Service: HttpReverseProxy/InjectPayload
public static readonly string InjectPayloadDir = Path.Combine(HttpReverseProxyServiceDir, @"plugins\Inject");
public static readonly string InjectPayloadConfigFilePath = Path.Combine(InjectPayloadDir, "plugin.config");
 
// Service: HttpReverseProxy/HostMapping
public static readonly string HostMappingDir = Path.Combine(HttpReverseProxyServiceDir, @"plugins\HostMapping");
public static readonly string HostMappingConfigFilePath = Path.Combine(HostMappingDir, "plugin.config");
 


// Registry
public static readonly string RegistrySoftwareName = "Minary";
public static readonly string BasisKey = string.Format(@"Software\{0}", Config.RegistrySoftwareName);

// Git
public static readonly string GitUser = "Minary";
public static readonly string GitEmail = "Minary@";

    #endregion


    #region PROPERTIES

    public static string OS { get; set; }

    public static string Architecture { get; set; }

    public static string Language { get; set; }

    public static string Processor { get; set; }

    public static string NumProcessors { get; set; }

    public static string DotNetVersion { get; set; }

    public static string CommonLanguateRuntime { get; set; }

    public static string WinPcap { get; set; }

    public static string APEFWRulesPath { get { return Path.Combine(Config.ApeServiceDir, Config.ApeFirewallRules); } }

    public static string APETargetHostsPath { get { return Path.Combine(Config.ApeServiceDir, Config.ApeTargetHosts); } }

    public static string DNSPoisoningHostsPath { get { return Path.Combine(Config.ApeServiceDir, Config.DnsPoisoningHosts); } }
    
    #endregion


    #region PUBLIC

    /// <summary>
    ///
    /// </summary>
    public static void InitializeMinaryConfig()
    {
      try
      {
        Config.OS = string.Format("{0}.{1}", Environment.OSVersion.Version.Major, Environment.OSVersion.Version.Minor);
      }
      catch (Exception)
      {
      }

      try
      {
        Config.Architecture = Environment.Is64BitOperatingSystem ? "x64" : "x86";
      }
      catch (Exception)
      {
      }

      try
      {
        Config.Language = System.Globalization.CultureInfo.CurrentCulture.ToString();
      }
      catch (Exception)
      {
      }

      try
      {
        Config.Processor = System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
      }
      catch (Exception)
      {
      }

      try
      {
        Config.NumProcessors = System.Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");
      }
      catch (Exception)
      {
      }

      try
      {
        Config.DotNetVersion = System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
      }
      catch (Exception)
      {
      }

      try
      {
        Config.CommonLanguateRuntime = Environment.Version.ToString();
      }
      catch (Exception)
      {
      }
    }


    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public static bool IsAdministrator()
    {
      bool hasUserElevatedPermissions;
      WindowsIdentity currentUserIdentity = WindowsIdentity.GetCurrent();
      WindowsPrincipal principal = new WindowsPrincipal(currentUserIdentity);
      hasUserElevatedPermissions = principal.IsInRole(WindowsBuiltInRole.Administrator);

      return hasUserElevatedPermissions;
    }

    #endregion

  }
}