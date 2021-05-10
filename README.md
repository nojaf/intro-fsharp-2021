# Intro to F# in 2021

## Get started

Create a free GitPod account at https://www.gitpod.io/ (Tip login with your GitHub account).

Fork this repository and create the following url:

`https://gitpod.io/#https://github.com/{your-user-name}/intro-fsharp-2021`

This should open and create your Gitpod workspace.

Checkout a new branch for your solution `git checkout -b solutions`.

Feel free to submit PRs with small fixes or typos if you encounted any. 

## Language features

Run a single unit test from the command line:

> cd src/LanguageFeatures

> dotnet test --filter DisplayName~'if / else if'

See https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests?pivots=xunit

F# Core Docs: https://fsharp.github.io/fsharp-core-docs/

## Tools

A couple useful .NET tools are installed in the [./.config/dotnet-tools.json](./.config/dotnet-tools.json) file.

### dotnet-scripts

Can be used to run the `*.csx` scripts in `src/intro-fp`.

See https://github.com/filipw/dotnet-script

### fantomas-tool

A tool to format your F# code.  
Run 

> dotnet fantomas src -r

to format all code.

See https://github.com/fsprojects/fantomas

### dotnet-fsharplint

Lint your F# code, useful for minor improvements.

> dotnet dotnet-fsharplint lint ./intro-fsharp-2021.sln

See https://github.com/fsprojects/FSharpLint

### fable

The F# to JavaScript compiler.

See https://fable.io/
