# Exchange CLI

This cli shows rate of exchange via this [free api](https://api.exchangerate.host/latest). 

``rate`` is default command to run. This command shows rates of turkish lira, dollar and euro as in picture below.

<img src="https://github.com/melihhtasci/exchange-cli/blob/main/doc_images/rate-command.png?raw=true" />
<br/>

Help command is similar like other CLIs. ``rate --h``

<img src="https://github.com/melihhtasci/exchange-cli/blob/main/doc_images/help.png?raw=true" />
<br/>

For other currencies, you can use --fr --to parameters. --am for exchange amount. 

<img src="https://github.com/melihhtasci/exchange-cli/blob/main/doc_images/all-commands.png?raw=true" />
<br/>

#### Packing

1. Edit project file and add these lines into PropertyGroup tag.
```
<PackAsTool>true</PackAsTool>
<ToolCommandName>rate</ToolCommandName>
<PackageOutputPath>./nupkg</PackageOutputPath>
```
2. run ``dotnet pack``
2. run ``dotnet tool install --global --add-source ./nupkg``




