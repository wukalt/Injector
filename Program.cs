#region Check Arguments

using Injector.Helpers;

if (args.Length is 0)
{
    Message.Print(Red, "args not found.");
    return;
}

if (!args.ContainsReqArgs())
{
    Message.Print(Red, "missing arg.");
    return;
}

#endregion

# region Control Inputs

string programCsPath = string.Empty;
bool applyChanges = false;

for (int i = 0; i < args.Length; i++)
{
    if (args[i] is "-path")
        programCsPath = args[i + 1];

    else if (args[i] is "-add")
        applyChanges = true;
}

if (applyChanges is false)
    return;

#endregion

#region Normilize Data

programCsPath = programCsPath.Trim();
string rootPath = programCsPath.Substring(0, programCsPath.Length - 10);

#endregion

#region Inject Code

var lines = File.ReadAllLines(programCsPath).ToList();

for (int i = 0; i < lines.Count; i++)
{
    if (lines[i].Contains("var builder"))
    {
        lines.Insert(i + 1, Constant.AuthProgramCs);
        lines.Insert(i + 2, Constant.DbContextProgramCs);
        break;
    }
}

File.WriteAllLines(programCsPath, lines);

Message.Print(Cyan, "Please specify your appsetting.json for inject connection string");
string appSettingJSONPath = ReadLine() ?? throw new Exception("null path is not alowed");

if (File.Exists(appSettingJSONPath))
{
    var appSettingContent = File.ReadAllLines(appSettingJSONPath).ToList();

    for (int i = 0; i < appSettingContent.Count; i++)
    {
        if (appSettingContent[i].Trim().Contains("AllowedHosts"))
        {
            appSettingContent.Insert(i + 1, Constant.ConnectionString);
            break;
        }
    }
    File.WriteAllLines(appSettingJSONPath, appSettingContent);
}

Message.Print(Yellow, "\t\t\nCreate your DbContext\n\n");

#endregion

#region Inject Utils

string repoUrl = "https://github.com/wukalt/WebUtils.git";
string destinationPath = @$"{rootPath}Utilities\";
try
{
    Message.Print(Yellow, $"Cloning repository from {repoUrl} to {destinationPath}...");
    Repository.Clone(repoUrl, destinationPath);
    Message.Print(Green, "Repository cloned successfully.");
}
catch (Exception ex)
{
    Message.Print(Yellow, $"Error cloning repository: {ex.Message}");
}

#endregion