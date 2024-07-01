import { useEffect, useState } from 'react'
import './App.css'

function App() {
  const [array, setArray] = useState([])
  const [photo, setPhoto] = useState({ url: '', type: ''})
  
  useEffect(() => {
    fetch('http://localhost:3000/photos')
      .then(res => res.json())
      .then(data => setArray(data))
  })
  
  const handleAdd = async (e) => {
    e.preventDefault()
    
    const res = await fetch(`http://localhost:3000/addPhoto?url=${photo.url}&type=${photo.type}`,
      {
        method: 'POST'
      }
    )
    
    const tmp_photo = await res.json()
    setArray([tmp_photo])
  }

  return (
    <>
      <div>
        <form onSubmit={handleAdd} className='form_box'>
          <input placeholder='URL' type="text" name='url' onChange={(e) => setPhoto({...photo, url: e.target.value})} />
          <input placeholder='Type' type="text" name='type' onChange={(e) => setPhoto({...photo, type: e.target.value})} />
          <button type="submit">Add</button>
        </form>
        
        <div className='photos'>
          <h1>Photos</h1>
          <hr/>
          
          {array.map((photo, i) => (
            <div key={i}>
              <img src={photo.url} alt={photo.type} />
              <h3>{photo.type}</h3>
            </div>
          ))}
        </div>
      </div>
    </>
  )
}

export default App
