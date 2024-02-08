import { useState, useEffect } from "react"
import { useDispatch, useSelector } from "react-redux"
import { fetchAddData, fetchDeleteData } from "../redux/getUsersData"
import { fetchContent } from "../redux/reducer"
import {Sentry} from 'react-activity/dist/Sentry'
import 'react-activity/dist/Sentry.css'

function Admin() {
  let [name, setName] = useState('')
  let [description, setDescription] = useState('')
  let [price, setPrice] = useState('')
  let [storeName, setStoreName] = useState('')
  let [storeAdress, setStoreAdress] = useState('')

  let [showEditor, setShowEditor] = useState({ active: false, action: '' })
  let [flag, setFlag] = useState(false)


  let dispatch = useDispatch()
  let usersArray = useSelector((state) => state.goods.usersArray)
  let addingInfo = useSelector((state) => state.goods.addingInfo)
  let deleting = useSelector((state) => state.goods.deletingInfo)
  let loading = useSelector((state) => state.goods.isLoading)
  let error = useSelector((state) => state.goods.error)

  useEffect(() => {
    dispatch(fetchContent())
  }, [dispatch, flag])

  if (loading) {
    return (
      <div className="admin-modal-container">
        <Spinner animation="border" role="status">
          <span className="visually-hidden">Loading...</span>
        </Spinner>
      </div>

    )
  }

  if (error) {
    return (
      <div className="admin-modal-container">

        <h1>ERROR...</h1>
      </div>

    )
  }
  return (
    <div className="admin">
      <h1>ADMIN</h1>
      <form onSubmit={(ev) => ev.preventDefault()}>
        <input placeholder="NAME" onChange={(ev) => setName(ev.target.value)} type="text" />
        <input placeholder="DESCRIPTION" onChange={(ev) => setDescription(ev.target.value)} type="text" />
        <input placeholder="PRICE" onChange={(ev) => setPrice(ev.target.value)} type="text" />
        <input placeholder="STORE NAME" onChange={(ev) => setStoreName(ev.target.value)} type="text" />
        <input placeholder="ADRESS" onChange={(ev) => setStoreAdress(ev.target.value)} type="text" />
        <button onClick={() => {
          dispatch(fetchAddData({
            product_name: name,
            product_description: description,
            product_price: price,
            store_name: storeName,
            store_address: storeAdress,
          }))
          setFlag(!flag)
          setShowModal({ active: true, action: 'ADD' })
        }}>ADD</button>
      </form>


      <ul className="goods">
        {usersArray.map((item) => {
          return (
            <li key={item.id}>
              <p>{item.product_name}</p>
              <p>{item.product_description}</p>
              <p>{item.product_price}</p>
              <p>{item.store_name}</p>
              <p>{item.store_address}</p>
              <button onClick={() => {
                dispatch(fetchDeleteData(item.id))
                setFlag(!flag)
                setShowModal({ active: true, action: 'DELETE' })
              }}>DELETE</button>
            </li>
          )
        })}
      </ul>
      {showModal.active && <div className="admin-modal-container">
        <div className="admin-modal">
          <p>{showEditor.action === 'ADD' ? addingInfo : deleting}</p>
          <button onClick={() => setShowEditor({ active: false, action: '' })}>OK</button>
        </div>
      </div>}
    </div>
  )
}

export default Admin