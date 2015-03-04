// Decompiled with JetBrains decompiler
// Type: Uno.Logger
// Assembly: Uno, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 94FF07B7-EA7B-4644-9D97-D71D388473C1
// Assembly location: C:\Users\Aviran\Downloads\Uno-1.3.0.0\Uno.exe

using System;
using System.IO;
using System.Windows.Forms;

namespace Uno
{
  internal class Logger
  {
    private static TextWriter m_fileLog;
    private static bool m_isOpen;

    public static void FuncInit(string funcName)
    {
      Logger.checkFileOpen();
      Logger.m_fileLog.WriteLine("\n" + (object) DateTime.Now + " - " + Logger.getLogLevelName(1) + " - Entering " + funcName);
      Logger.m_fileLog.Flush();
    }

    public static void FuncExit(string funcName)
    {
      Logger.checkFileOpen();
      Logger.m_fileLog.WriteLine("\n" + (object) DateTime.Now + " - " + Logger.getLogLevelName(1) + " - Exiting " + funcName);
      Logger.m_fileLog.Flush();
    }

    private static void checkFileOpen()
    {
      if (Logger.isLogFileOpen())
        return;
      Logger.openLogFile("Uno.log");
    }

    public static void Write(int logLevel, string message)
    {
      Logger.checkFileOpen();
      int num = logLevel & Data.LogLevel;
      if (Data.LogLevel > 1 && num == logLevel)
        Logger.m_fileLog.WriteLine("\n" + (object) DateTime.Now + " - " + Logger.getLogLevelName(logLevel) + " - " + message);
      else if (1 == logLevel)
        Logger.m_fileLog.WriteLine("\n" + (object) DateTime.Now + " - " + Logger.getLogLevelName(1) + " - " + message);
      Logger.m_fileLog.Flush();
    }

    private static string getLogLevelName(int logLevel)
    {
      switch (logLevel)
      {
        case 1:
          return "LOG GENERAL";
        case 3:
          return "LOG DEBUG";
        default:
          return "LOG <Unknown>";
      }
    }

    private static bool isLogFileOpen()
    {
      return Logger.m_isOpen;
    }

    private static void openLogFile(string fileName)
    {
      Logger.m_fileLog = (TextWriter) new StreamWriter(Application.StartupPath + "\\" + fileName, true);
      Logger.m_isOpen = true;
      Logger.m_fileLog.WriteLine("\n----------------- Uno log starting -----------------");
      Logger.m_fileLog.Flush();
    }
  }
}
