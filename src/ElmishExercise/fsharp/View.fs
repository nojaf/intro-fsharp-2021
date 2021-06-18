module ElmishExercise.View

open ElmishExercise.Model
open Fable.React
open Fable.React.Props

let view (model: Model) (dispatch: Msg -> unit) : ReactElement =
    let errors =
        model.Errors
        |> List.map (fun e -> p [ Style [ Color "red" ] ] [ str e ])

    div [ Class "main-container" ] [
        hr []
        form [ OnSubmit
                   (fun ev ->
                       ev.preventDefault ()
                       dispatch FormSubmit) ] [
            div [] [
                label [] [ str "Username" ]
                input [ OnChange(fun e -> UpdateUser e.Value |> dispatch) ]
            ]
            div [] [
                label [] [ str "Email" ]
                input [ OnChange(fun e -> UpdateEmail e.Value |> dispatch) ]
            ]
            div [] [
                label [] [ str "Password" ]
                input [ Type "password"
                        OnChange(fun e -> UpdatePassword e.Value |> dispatch) ]
            ]
            button [ Type "submit" ] [
                str "submit"
            ]
            br []
            ofList errors
            if model.UserDidSubmit && List.isEmpty model.Errors then
                p [ Style [ Color "green" ] ] [
                    str "Valid data!"
                ]
        ]
    ]
