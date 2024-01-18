import { useReducer, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)
  const [users, dispatch] = useReducer(usersReducer, initialUser)
  
  function addUser({name, surname, age}) {
    dispatch({
      name: name,
      surname: surname,
      age: age,
    });
  }
  
  return (
    <>
      <div>
        <label>
          Name:
          <input type="text" name="name" onChange={handleInputChange} />
        </label>
      </div>
      <div>
        <label>
          Surname:
          <input type="text" name="surname"  onChange={(e) => setText(e.target.value)} />
        </label>
      </div>
      <div>
        <label>
          Age:
          <input type="text" name="age" onChange={(e) => setText(e.target.value)} />
        </label>
      </div>
      <button onClick={addUser}>Add</button>
      <ul>
        {
          users.map((user) => {
            return(
              <li>
              <p>{user.name}</p>
              <p>{user.surname}</p>
              <p>{user.age}</p>
            </li>
          )
        })
      }
      </ul>
    </>
  )
}

function usersReducer(users, action){
  return [
    ...users,
    {
      name: action.name,
      surname: action.surname,
      age: action.age
    }
  ];
}

const initialUser = [{
  name: '',
  surname: '',
  age: ''
}]

export default App