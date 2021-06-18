module LanguageFeatures.FormattedPrinting

open System
open Xunit

(*

F# also has the concept of creating formatted strings.
The `sprintf` and `printf(n)` functions can be parameterized based on the content of the string format.

see: https://fsharpforfunandprofit.com/posts/printf/

*)

[<Fact>]
let ``#9.1, A gentle string`` () =
    let printName = sprintf "Greetings, my name is %s"
    let result = printName "John"

    Assert.Equal("Greetings, my name is John", result)

[<Fact>]
let ``#9.2, integers`` () =
    // TODO: update the string so the value i can be passed as an argument
    let printInt i = sprintf "The value is %i" i

    Assert.Equal("The value is 7", printInt 7)

[<Fact>]
let ``#9.3, money`` () =
    // TODO: update string format
    let printCurrency euros = sprintf "€%0.2f" euros

    Assert.Equal("€0.02", printCurrency 0.02)
    Assert.Equal("€17.00", printCurrency 17.)

[<Fact>]
let ``#9.4, print fallback`` () =
    // TODO: update string format
    let dump a = sprintf "All: %A" a

    Assert.Equal("All: [1; 2; 3]", dump [ 1; 2; 3 ])
    Assert.Equal("All: 7.28", dump 7.28)
    Assert.Equal("All: System.Object", dump (obj ()))

[<Fact>]
let ``#9.5, print dates`` () =
    // TODO: update string format
    let printDate (d: DateTime) = d.ToString "yyyy-MM-dd"

    Assert.Equal("2001-10-17", printDate (DateTime(2001, 10, 17)))

// In F# 5, you can also interpolated strings.
// https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/interpolated-strings

[<Fact>]
let ``#9.6, string interpolation`` () =
    let n = 9
    let s = $"The number n is {n}"
    Assert.Equal("The number n is 9", s)
