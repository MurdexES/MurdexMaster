import { useState } from 'react'
import './App.css'
import { Routes, Route } from 'react-router-dom'
import UserPage from './assets/UserPage'
import RegisterPage from './assets/RegisterPage'

function App() {

  return (
    <>
      <div>
        <Routes>
          <Route path='/' element={<RegisterPage />}/>
          <Route path='/logged' element={<UserPage />}/>
        </Routes>
      </div>
    </>
  )
}

export default App
