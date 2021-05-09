module ElmishExercise.View

open ElmishExercise.Model
open Fable.React
open Fable.React.Props

let view (model: Model) (dispatch: Msg -> unit) : Fable.React.ReactElement =
    let errors = []

    div [ Class "main-container" ] [
        hr []
        form [ OnSubmit(fun ev -> ev.preventDefault ()) ] [
            div [] [
                label [] [ str "Username" ]
                input []
            ]
            div [] [
                label [] [ str "Email" ]
                input []
            ]
            div [] [
                label [] [ str "Password" ]
                input [ Type "password" ]
            ]
            button [ Type "submit" ] [
                str "submit"
            ]
            ofList errors
        ]
    ]
