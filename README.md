# Injector

<p>first of all this is not a complete and good app for your use.</p>
<b>this is my little stupid idea for injecting code in my web proj</b>
<p>use it by your decision ... </p>
<b>a command line app for inject dependencies (not copy and paste code)</b>

## Items
the dependencies that are add into your proj are : 
- Identity Core (you should config the controller manually)
- Add Connection String (you should change db name and check the hole string)
- Add Web Utilities (from my web utils repo)

## Usage Example

just enter the path of your program.cs file and done.
(before use the app make sure you have a backup)

format : 
```pwsh
Injector -path [PATH] -add
```

-add is req for inject. if it's not included the changes are not applied.
