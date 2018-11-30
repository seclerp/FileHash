module HashTools

open System.IO;

let getLastBits num n = 
    num &&& ((1 <<< n) - 1)

let getHash bytesList numBits =
    let mutable hashValue = 2139062143
    for byte in bytesList do
        hashValue <- 37 * hashValue + byte
    getLastBits hashValue numBits

let getFileHash fileName =
    fileName 
    |> File.ReadAllBytes 
    |> Array.map int
    |> getHash