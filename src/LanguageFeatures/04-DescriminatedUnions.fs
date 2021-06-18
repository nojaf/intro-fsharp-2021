module LanguageFeatures.DiscriminatedUnions

open System
open Xunit

(*
    My personal favorite: Discriminated Unions!
    This is a feature related to sum types in category theory and incredibly useful for code correctness.
    ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/discriminated-unions
*)

type SprintMetric =
    { Velocity: int
      Duration: int
      CostPerSprint: double }

// Notice that we need to define the type SprintMetric before we can use it later in SoftwareDevelopmentPurchase.
// The order matters, you can't use anything in F# before it is defined.

type SoftwareDevelopmentPurchase =
    | FixedPrice of price: double * start: DateTime * deadline: DateTime // We can assign labels (like price:) to union case members.
    | Agile of SprintMetric * totalStoryPoints: int
    | ExistingProduct of double

[<Fact>]
let ``#4.1, unions types`` () =
    // hint: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/pattern-matching#identifier-patterns
    let getPrice (p: SoftwareDevelopmentPurchase) : double =
        // The price of a purchase will be different for each union case.
        // FixedPrice and ExistingProduct are easy to deduce.

        // Agile has a slightly more complex calculation: you know the total amount of story points that will be necessary to complete the project.
        // You need to pay the scrum team for per sprint (each started sprint needs to be payed in full).
        // After each sprint the velocity of story points will be delivered.
        // So, first you need to figure out how many sprint will be necessary to complete the total amount of story points.

        failwith<double> "TODO" // TODO complete!

    let fixedPriceProject : SoftwareDevelopmentPurchase =
        SoftwareDevelopmentPurchase.FixedPrice(10000., DateTime(1997, 10, 2), DateTime(1998, 2, 7)) // notice that we don't need the `new` keyword when creating those dates.

    let fixedPrice = getPrice fixedPriceProject
    Assert.Equal(10000., fixedPrice)

    let agileProject =
        Agile(
            { Velocity = 20
              Duration = 10
              CostPerSprint = 5000. },
            70
        ) // Notice that we don't need to write SoftwareDevelopmentPurchase.Agile.

    let agilePrice = getPrice agileProject

    Assert.Equal(20000., agilePrice)

    let existingProduct = ExistingProduct(37000.)
    let existingProductPrice = getPrice existingProduct

    Assert.Equal(37000., existingProductPrice)

[<Fact>]
let ``#4.2, delivery date`` () =
    // TODO: get the duration of each project in days
    // Tip, you can subtract two Dates in .NET and retrieve a TimeSpan:
    // ref: https://docs.microsoft.com/en-us/dotnet/api/system.datetime.subtract?view=net-5.0
    // https://docs.microsoft.com/en-us/dotnet/api/system.timespan.totaldays?view=net-5.0
    let getDuration (p: SoftwareDevelopmentPurchase) : int =
        failwith<int> "TODO" // TODO complete

    let fixedPriceProject =
        FixedPrice(double (10000.), DateTime(1997, 10, 2), DateTime(1998, 2, 7))

    let agileProject =
        Agile(
            { Velocity = 20
              Duration = 10
              CostPerSprint = 5000. },
            70
        )

    let existingProduct = ExistingProduct(37000.)

    Assert.Equal(128, getDuration fixedPriceProject)
    Assert.Equal(40, getDuration agileProject)
    Assert.Equal(0, getDuration existingProduct)

[<Fact>]
let ``#4.3, popular sum type`` () =
    // Option and Result are built in type into FSharp.Core.
    // ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/options
    // ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/results
    let some6 = Some 6
    let none = None
    let ok = Ok "Ringo"
    let error = Error "something went wrong"

    let optionToString o = "todo"
    let resultToString r = "todo"

    Assert.Equal("6", optionToString some6)
    Assert.Equal("None", optionToString none)
    Assert.Equal("Ringo", resultToString ok)
    Assert.Equal("something went wrong", resultToString error)

// Outside the scope of this training but Results are the basis for Railway Oriented programming: https://fsharpforfunandprofit.com/rop/
// To wrap up this module, format all the files in the project by passing the path to a folder this time
//      dotnet fantomas ./
