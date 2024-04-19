import { useState } from 'react'
import { useDispatch } from 'react-redux'
import { editData } from '../redux/getUsersData'
import { Card } from 'antd'

function Editor({setShowEditor, id}){
    let [name, setName] = useState('')
    let [description, setDescription] = useState('')
    let [price, setPrice] = useState('')
    let [storeName, setStoreName] = useState('')
    let [storeAdress, setStoreAdress] = useState('')
    let dispatch = useDispatch()
    function Update(){
        dispatch(editData({
            id: id,
            product_name: name,
            product_description: description,
            product_price: price,
            store_name: storeName,
            store_address: storeAdress
        }))
        setShowModal(false)
    }
    return (
        <Card className="modal-container">
        <div className="modal">
            <button className="modalExit" onClick={() => setShowModal(false)}>Exit X</button>
            <h2>Editor</h2>
            <input onChange={(ev) => setName(ev.target.value)} type="text" placeholder="Title"/>
            <input onChange={(ev) => setDescription(ev.target.value)} type="text" placeholder="Description"/>
            <input onChange={(ev) => setPrice(ev.target.value)} type="number" placeholder="Price"/>
            <input onChange={(ev) => setStoreName(ev.target.value)} type="text" placeholder="Store Name"/>
            <input onChange={(ev) => setStoreAdress(ev.target.value)} type="text" placeholder="Store Address"/>
            <button onClick={() => Update()}>Edit</button>
        </div>
        </Card>
    )
}

export default Editor