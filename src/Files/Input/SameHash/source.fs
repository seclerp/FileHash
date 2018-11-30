open System
open System.IO

let filesPath = "Files/Input"
let resultsFile = "Files/Result.txt"
let resultsFileStartContent = "Result hashes:\n\n"
let hashBits = 4

let clearResults () = 
    File.WriteAllText(resultsFile, resultsFileStartContent)

let getFileHashInfo fileName (fileHash:int) =
    " - " + fileName + ": " + Convert.ToString (fileHash, 2) + "\n"

[<EntryPoint>]
let main argv =
    clearResults ()
    let hashesInfo = 
        Directory.GetFiles(filesPath) 
        |> Seq.map 
            (fun fileName -> HashTools.getFileHash fileName hashBits |> getFileHashInfo fileName)
        |> Seq.reduce (+)
    File.AppendAllText (resultsFile, hashesInfo)
    printfn "Done"
    0