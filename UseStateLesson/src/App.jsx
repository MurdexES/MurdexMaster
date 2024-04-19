import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

import Header from './Header'
import Home from './Home'
import Footer from './Footer'

function App() {
  const [count, setCount] = useState(0)
  const [array, setArray] = useState([
    {name : 'John', surname : 'Smith'},
    {name : 'Jason', surname : 'Shrier'},
    {name : 'Will', surname : 'Hawking'}
  ])

  return (
    <>
      <Header array={array[0]}></Header>
      <Home array={array[1]}></Home>
      <Footer array={array[2]}></Footer>
    </>
  )
}

export default App
