module LanguageFeatures.DiscriminatedUnions

open System
open Xunit

(*
    My personal favorite: Discriminated Unions!
    This is a feature related to sum types in category theory and incredibly useful for code correctness.
    ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/discriminated-unions
*)

type Days = Days of int // you can alias types in F# to get a DDD kind of vibe.

type StoryPoints = StoryPoints of int
type Money = Money of double

type SprintMetric =
    { Velocity: StoryPoints
      Duration: Days
      CostPerSprint: Money }

// Notice that we need to define the type SprintMetric before we can use it later in SoftwareDevelopmentPurchase.
// The order matters, you can't use anything in F# before it is defined.

type SoftwareDevelopmentPurchase =
    | FixedPrice of price: Money * start: DateTime * deadline: DateTime // We can assign labels (like price:) to union case members.
    | Agile of SprintMetric * totalStoryPoints: StoryPoints
    | ExistingProduct of Money

[<Fact>]
let ``single case discriminated unions`` () =
    let tenDays = Days 10 // notice that the primitive value 10 is being wrapped by our Days type
    // This helps us and the compiler to distinguish what a value really means.
    let (Days (d)) = tenDays // destructure of get the actual value
    Assert.Equal(10, d)

// hint: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/pattern-matching#identifier-patterns
let getPrice p : Money = Money 0. // TODO complete!
let getDuration p : Days = Days 0 // TODO complete

[<Fact>]
let ``unions types`` () =
    let fixedPriceProject =
        SoftwareDevelopmentPurchase.FixedPrice(Money(10000.), DateTime(1997, 10, 2), DateTime(1998, 2, 7)) // notice that we don't need the `new` keyword when creating those dates.
    // fixedPrice is now of type SoftwareDevelopmentPurchase.
    // try and extract the price again, create a helper function outside this unit test to get the price of any given SoftwareDevelopmentPurchase

    let fixedPrice = getPrice fixedPriceProject

    Assert.Equal(Money(10000.), fixedPrice)

    let agileProject =
        Agile(
            { Velocity = StoryPoints(20)
              Duration = Days(10)
              CostPerSprint = Money(5000.) },
            StoryPoints(70)
        ) // Notice that we don't need to write SoftwareDevelopmentPurchase.Agile.

    let agilePrice = getPrice agileProject

    Assert.Equal(Money(200000.), agilePrice)

    let existingProduct = ExistingProduct(Money(37000.))
    let existingProductPrice = getPrice existingProduct

    Assert.Equal(Money(37000.), existingProductPrice)

[<Fact>]
let ``delivery date`` () =
    let fixedPriceProject =
        FixedPrice(Money(10000.), DateTime(1997, 10, 2), DateTime(1998, 2, 7))

    let agileProject =
        Agile(
            { Velocity = StoryPoints(20)
              Duration = Days(10)
              CostPerSprint = Money(5000.) },
            StoryPoints(70)
        )

    let existingProduct = ExistingProduct(Money(37000.))

    Assert.Equal(Days(128), getDuration fixedPriceProject)
    Assert.Equal(Days(40), getDuration agileProject)
    Assert.Equal(Days(0), getDuration existingProduct)

[<Fact>]
let ``popular sum type`` () =
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
