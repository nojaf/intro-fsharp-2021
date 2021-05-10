module ElmishExercise.Counter

open Fable.React
open Fable.React.Props
open Elmish

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

open Elmish.React

Program.mkSimple init update view
|> Program.withReactBatched "root"
|> Program.run
