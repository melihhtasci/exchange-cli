# Exchange CLI

This cli shows rate of exchange via this [free api](https://api.exchangerate.host/latest). 

``rate`` is default command to run. 
This command shows 1 dollar and euro value opposing turkish lira as in picture below.

<img src="https://github.com/melihhtasci/exchange-cli/blob/main/doc_images/default.png?raw=true" />
<br/>

Help command is similar like other CLIs. ``rate --h``

<img src="https://github.com/melihhtasci/exchange-cli/blob/main/doc_images/help.png?raw=true" />
<br/>

On previos version, i was using ``Option`` to get parameters. 
We were supposed to use parameter by dash. I changed it with ``Argument``. 

You can see the usage in picture below

<img src="https://github.com/melihhtasci/exchange-cli/blob/main/doc_images/command-1.png?raw=true" />
<br/>


<img src="https://github.com/melihhtasci/exchange-cli/blob/main/doc_images/command-2.png?raw=true" />
<br/>


<img src="https://github.com/melihhtasci/exchange-cli/blob/main/doc_images/error.png?raw=true" />
<br/>

#### Packing

1. Edit project file and add these lines into PropertyGroup tag.
```
<PackAsTool>true</PackAsTool>
<ToolCommandName>rate</ToolCommandName>
<PackageOutputPath>./nupkg</PackageOutputPath>
```
2. run ``dotnet pack``
2. run ``dotnet tool install --global --add-source ./nupkg exchange-cli``




