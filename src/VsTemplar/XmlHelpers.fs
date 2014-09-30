﻿module VsTemplar.XmlHelpers

open System.Xml.Linq

let ofOption = function | null -> None | i -> Some i
    
let xName name = XName.op_Implicit name 
let xNameNS name ns = XName.Get(name, ns)

let getXElemNS childName (elem:XElement) = 
    ofOption <| elem.Element(childName)

let getXElem childName (elem:XElement) = 
    getXElemNS (xName childName) elem
    
let setXElemValueNS childName newValue (elem:XElement) = 
    match getXElemNS childName elem with
    | Some child -> child.Value <- newValue
    | None -> ()
    elem

let setXElemValue childName newValue (elem:XElement) = 
    setXElemValueNS (xName childName) newValue elem

let setXThisValue (newValue:string) (elem:XElement) =
    elem.SetValue(newValue)
    elem

let addChildXElem (child:XElement) (elem:XElement) =
    elem.Add(child)
    elem

let getXAttr attrName (elem:XElement) = 
    ofOption <| elem.Attribute(xName attrName)

let setXAttrValue attrName newValue (elem:XElement) =
    match getXAttr attrName elem with
    | Some attr -> attr.Value <- newValue
    | None -> ()
    elem

