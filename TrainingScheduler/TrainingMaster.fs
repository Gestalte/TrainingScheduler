namespace TrainingScheduler

open Fabulous
open Fabulous.XamarinForms
open TrainingScheduler.Models
open Xamarin.Forms

module TrainingMaster =
    
    type Msg =
        | NewTraining
        | RemoveTraining of Training
        | MoveTraining

    type Model =
        {PlannedTraining: Training list option}

    let init () =
        {PlannedTraining=None}
        
    let update msg model =
        match msg with
        | RemoveTraining training ->
            match model.PlannedTraining with
            | Some plannedTraining ->
                let fileteredTraining = plannedTraining |> List.filter (fun a -> a <> training)
                {model with PlannedTraining = Some fileteredTraining}
            | None ->
                model
        
    let view (model:Model) dispatch =
        View.ContentPage(            
            View.StackLayout(
                children = [                
                    View.Label(
                        text = "Training Scheduler",
                        fontSize = FontSize.fromNamedSize NamedSize.Title,
                        horizontalOptions = LayoutOptions.Center
                    )

                    match model.PlannedTraining with
                        | Some trainingList ->
                            View.ListView(
                                items = List.map (fun training -> 
                                    View.TextCell(
                                        text = training.Title,
                                        contextActions = [
                                            View.MenuItem(
                                                text="Complete", 
                                                command = fun () -> dispatch(RemoveTraining training)
                                            )
                                        ]
                                    ) 
                                ) trainingList
                            )
                        | None ->
                            View.Label(
                                text="No items to display",
                                horizontalOptions = LayoutOptions.Center
                            )
                ]
            )
        )
        
    let program =
        XamarinFormsProgram.mkSimple init update view
#if DEBUG
        |> Program.withConsoleTrace
#endif

type App () as app = 
    inherit Application ()

    let runner = 
        TrainingMaster.program
        |> XamarinFormsProgram.run app