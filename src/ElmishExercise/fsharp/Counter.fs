module ElmishExercise.Counter

open Fable.React
open Fable.React.Props
open Elmish
open Feliz
open Feliz.UseElmish

// MODEL

type Model = int

type Msg =
    | Increase
    | Decrease

let init () : Model = 0

// UPDATE

let update (msg: Msg) (model: Model) : Model =
    match msg with
    | Increase -> model + 1
    | Decrease -> model - 1

// VIEW (rendered with React)

let view (model: Model) (dispatch: Msg -> unit) : ReactElement =
    let title = $"Current state: {model}"

    div [ Class "main-container" ] [
        h1 [] [ str title ]
        div [ ClassName "actions" ] [
            button [ OnClick(fun _ -> dispatch Increase)
                     Style [ MarginRight "10px" ] ] [
                str "+"
            ]
            button [ OnClick(fun _ -> dispatch Decrease) ] [
                str "-"
            ]
        ]
    ]

[<ReactComponent>]
let Counter () =
    let model, dispatch =
        React.useElmish ((init (), Cmd.none), (fun msg model -> update msg model, Cmd.none), [||])

    view model dispatch
