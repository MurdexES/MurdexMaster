import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import ModalWindow from './ModalWindow'
import Users from './Users'

function App() {
  const [value, setValue] = useState("")
  const [showId, setShowId] = useState(0)
  const [idArray, setIdArray] = useState([])
  const [array, setArray] = useState([])
  const [showKey, setShowKey] = useState(false)

  return (
    <>
      <div>
        {showKey ? null : <Users value={value} array={array} setArray={setArray} setValue={setValue} setShowId={setShowId} setShowKey={setShowKey}/>}
        {showKey ? <ModalWindow value={value} idArray={idArray} setIdArray={setIdArray} setShowKey={setShowKey} showId={showId} /> : null}
      </div>
    </>
  )
}

export default App
