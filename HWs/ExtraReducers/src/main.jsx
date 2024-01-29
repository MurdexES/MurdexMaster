import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import { BrowserRoute } from "react-router-dom"
import { Provider } from 'react-redux'

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <BrowserRoute>
    <Provider store={appl}>
    <App />
    </Provider>
    </BrowserRoute>
  </React.StrictMode>,
)
