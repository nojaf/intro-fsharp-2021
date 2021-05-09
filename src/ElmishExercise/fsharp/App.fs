module ElmishExercise.App

open Feliz
open Elmish
open Feliz.UseElmish
open ElmishExercise

[<ReactComponent>]
let App () =
    let model, dispatch =
        React.useElmish ((State.init (), Cmd.none), (fun msg model -> State.update msg model, Cmd.none), [||])

    View.view model dispatch
