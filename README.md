# JKCron

## About JKCron

JKCron is a command line application which parses a cron string and expands each field to show the times at which it will run.

Example :

```JKCron.exe */15 0 1,15 * 1-5 /usr/bin/find```

Will output :

```console
minute          0 15 30 45
hour            0
day of month    1 15
month           1 2 3 4 5 6 7 8 9 10 11 12
day of week     1 2 3 4 5
command         /usr/bind/find
```

## How to build, test and run the project

The project is built with .NET Core 2.1, you need to download and install the SDK [here](https://dotnet.microsoft.com/download/dotnet-core/2.1).

Then you are able to build, test and run the project :

* `dotnet build` to build the project.
* `dotnet test` to run all the tests of the project
* `dotnet .\JKCron\bin\Debug\netcoreapp2.1\JKCron.dll <minute> <hour> <day of month> <month> <day of week> <command>` to run the project

## The structure of the project

There is two projects :

* *JKCron* - Contains the production code
* *JKCron.Tests* - Contains all the tests. I used a GWT approch to wrote them, you can have a look [here for more informations](https://martinfowler.com/bliki/GivenWhenThen.html)

## Where to begin

My thought is to start with the test, there are pretty straightforward and you can have a look on each capabilities implemented on the project.
