import { useState } from 'react'
import './App.css'

function App() {
  const [result, setResult] = useState('')
  const [inputs, setInputs] = useState({
    input1: '',
    input2: '',
    input3: '',
    input4: '',
    input5: '',
  });

  const create = async () => {
    const query = `input1=${encodeURIComponent(inputs.input1)}&input2=${encodeURIComponent(inputs.input2)}&input3=${encodeURIComponent(inputs.input3)}&input4=${encodeURIComponent(inputs.input4)}&input5=${encodeURIComponent(inputs.input5)}`;
    const res = await fetch(`http://localhost:3000/bufferToFile?${query}`,
    {
      method: 'POST'
    });
    
    const data = await res.text()
    setResult(data)
  }

  return (
    <>
      <div className='main_box'>
        <div className='inputs_box'>
          <input id="input1" onChange={(e) => setInputs({...inputs, input1: e.target.value})}/>
          <input id="input2" onChange={(e) => setInputs({...inputs, input2: e.target.value})}/>
          <input id="input3" onChange={(e) => setInputs({...inputs, input3: e.target.value})}/>
          <input id="input4" onChange={(e) => setInputs({...inputs, input4: e.target.value})}/>
          <input id="input5" onChange={(e) => setInputs({...inputs, input5: e.target.value})}/>
        </div>

        <hr/>
        
        <button onClick={() => create()}>Create</button>
        
        <h2>Outcome:</h2>
        <p>{result}</p>
      </div>
    </>
  )
}

export default App
