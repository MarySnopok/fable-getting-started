module App

open Browser.Dom
open Fable.Core
open Fable.Core.JsInterop

// get references for UI elements
let increase = document.getElementById "increase"
let decrease = document.getElementById "decrease"
let countViewer = document.getElementById "countViewer"
let increaseDelayed = document.getElementById "increaseDelayed"
let refreshView = document.getElementById "refresh"

let mutable currentCount = 0

let rnd = System.Random()


refreshView.onclick <- fun ev ->
    currentCount <- 0
    countViewer.innerText <- sprintf "Count is at %d" currentCount

// attach event handlers
increase.onclick <- fun ev ->
    currentCount <- currentCount + rnd.Next(5, 10)
    countViewer.innerText <- sprintf "Count is at %d" currentCount

decrease.onclick <- fun ev ->
    currentCount <- currentCount - rnd.Next(5, 10)
    countViewer.innerText <- sprintf "Count is at %d" currentCount

// set the count viewer with the initial count
countViewer.innerText <- sprintf "Count is at %d" currentCount

let runAfter (ms: int) callback =
  async {
    do! Async.Sleep ms
    do callback()
  }
  |> Async.StartImmediate

increaseDelayed.onclick <- fun _ ->
  runAfter 1000 (fun () ->
    currentCount  <- currentCount  + rnd.Next(5, 10)
    countViewer.innerText <- sprintf "Count is at %d" currentCount
  )