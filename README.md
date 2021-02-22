# CalculatorService
CalculatorService Test

## Requirements
.NET Core 3.1 Framework
Visual Studio 2019 or higher

## Packages
This test uses some NuGet packages:

### Server
* Serilog: Common logger.

### Client
* CommandLineParser: Command line argument analyzer.
* Flurl: Fluent URL management.

## Build
dotnet build

## Deploy
dotnet publish -p:PublishProfile=FolderProfile

## Run

There are two options to test: 

* Using the provided Postman.json file.
* Using the command line tool.

### Postman file

Import the provided file and use the collection items to test the results.

### Command line tool

#### General parameters
All verbs support the --t / --trackingId parameter to specify the Tracking Id value.

#### Add verb
usage: 

CalculatorService.Client.exe add --n [numbers]

Parameters: 

--n [numbers]: space separated values to add.

#### Div verb
usage: 

CalculatorService.Client.exe div --d [dividend] -o [divisor]

Parameters: 

--d [dividend]: Dividend

--o [divisor]: Divisor

#### Mult verb
usage: 

CalculatorService.Client.exe mult --f [factors]

Parameters: 

--f [factors]: space separated values to multiply.

#### Square verb
usage: 

CalculatorService.Client.exe sqrt --n [number]

Parameters: 

--n [number]: Number to calculate the square.

#### Sub verb
usage: 

CalculatorService.Client.exe sub -m [minuend] -s [sustraend]

Parameters: 

--m [minuend]: Minuend.

--s [sustraend]: Sustraend.

#### Journal verb
usage: 

CalculatorService.Client.exe journal --t [trackingId]

Parameters: 

--t [trackingId]: Tracking Id to query.


