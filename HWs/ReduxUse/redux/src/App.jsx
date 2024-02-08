import { useState } from 'react'
import './App.css'
import { Route, Routes } from 'react-router-dom'
import Header from './components/Header'
import Home from './components/Home'
import Admin from './components/Admin'
import MyBag from './components/MyBag'

function App() {
  const [query, setQuery] = useState('')

  return (
    <>
      <Header setQuery={setQuery}/>
      <Routes>
        <Route path='/' element={<Home query={query}/>}/>
        <Route path='/admin' element={<Admin/>}/>
        <Route path='/my-bag' element={<MyBag/>}/>
      </Routes>
    </>
  )
}

export default App
