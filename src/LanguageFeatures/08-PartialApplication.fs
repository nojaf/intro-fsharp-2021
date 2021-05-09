module LanguageFeatures.PartialApplication

open Xunit

(*

In F# you can call a function with less parameters that it needs,
the return value will be a new function that takes the remaining parameters

see: https://fsharpforfunandprofit.com/posts/partial-application/
*)

[<Fact>]
let ``classic example`` () =
    let add a b = a + b
    let add50 = add 50

    Assert.Equal(70, add50 20)
