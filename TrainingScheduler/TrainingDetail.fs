namespace TrainingScheduler

open Fabulous
open Fabulous.XamarinForms
open TrainingScheduler.Models
open Xamarin.Forms

module TrainingDetail =

    type Msg =
        | DeleteTraining of Training
        | SaveTraining of Training

    type Model =
        {Training:Training option}

    let init () =
        {Training=None}

    let update msg model =
        match msg with
            | SaveTraining training ->                
                {model with Training = None}
            | DeleteTraining training ->
                {model with Training = None}

    let view (model:Model) dispatch =
        View.ContentPage(            
            View.StackLayout(
                children=[
                    View.Label(
                        text = "Create or Edit Training Session",
                        fontSize = FontSize.fromNamedSize NamedSize.Title,
                        horizontalOptions = LayoutOptions.Center
                    )

                    View.Entry(                                                
                        placeholder="Title"                       
                    )

                    View.Entry(                        
                        placeholder="Description"
                    )
                ]
            ),
            toolbarItems = [
                View.ToolbarItem(
                    text = "Save"
                )                
            ]
        )

    let program =
        XamarinFormsProgram.mkSimple init update view
#if DEBUG
        |> Program.withConsoleTrace
#endif