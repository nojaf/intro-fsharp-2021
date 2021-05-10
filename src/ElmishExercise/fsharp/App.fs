module ElmishExercise.App

open Feliz
open Elmish
open Feliz.UseElmish
open ElmishExercise

(*
    Complete the form:
        - give feedback when there is invalid input (display errors)
        - username should not be empty
        - email should be valid
        - password should have a capital letter, a number and be 8 chars long
*)

[<ReactComponent>]
let App () =
    let model, dispatch =
        // In a true Elm application there is also the notion of Commands.
        // See: https://elmish.github.io/elmish/#Commands
        // We are not using this functionality here, so we are wrapping the functions
        // to not have to deal with that.
        React.useElmish (
            (fun () -> (State.init (), Cmd.none)),
            (fun msg model -> State.update msg model, Cmd.none),
            [||]
        )

    View.view model dispatch
