import { useReducer, useState } from 'react'
import './App.css'

function App() {
  const [name, setName] = useState("")
  const [username, setUsername] = useState("")
  const [email, setEmail] = useState("")
  
  const [usersArray, setUsers] = useState([
    {
      "id": 1,
      "name": "Leanne Graham",
      "username": "Bret",
      "email": "Sincere@april.biz"
    },
    {
      "id": 2,
      "name": "Ervin Howell",
      "username": "Antonette",
      "email": "Shanna@melissa.tv"
    },
    {
      "id": 3,
      "name": "Clementine Bauch",
      "username": "Samantha",
      "email": "Nathan@yesenia.net"
    },
    {
      "id": 4,
      "name": "Patricia Lebsack",
      "username": "Karianne",
      "email": "Julianne.OConner@kory.org"
    },
    {
      "id": 5,
      "name": "Chelsey Dietrich",
      "username": "Kamren",
      "email": "Lucio_Hettinger@annie.ca"
    },
    {
      "id": 6,
      "name": "Mrs. Dennis Schulist",
      "username": "Leopoldo_Corkery",
      "email": "Karley_Dach@jasper.info"
    },
    {
      "id": 7,
      "name": "Kurtis Weissnat",
      "username": "Elwyn.Skiles",
      "email": "Telly.Hoeger@billy.biz"
    },
    {
      "id": 8,
      "name": "Nicholas Runolfsdottir V",
      "username": "Maxime_Nienow",
      "email": "Sherwood@rosamond.me"
    },
    {
      "id": 9,
      "name": "Glenna Reichert",
      "username": "Delphine",
      "email": "Chaim_McDermott@dana.io"
    },
    {
      "id": 10,
      "name": "Clementina DuBuque",
      "username": "Moriah.Stanton",
      "email": "Rey.Padberg@karina.biz"
    }
  ])


  const [users, dispatch] = useReducer(usersReducer, usersArray);
  
  function handleAdd(name, email, username) {
    dispatch({
      type: 'add',
      id: String(Number(users.at(-1).id) + 1),
      name: name,
      email: email,
      username: username
    });
  }
  
  function handleEdit(id, name, email, username) {
    dispatch({
      type: 'edit',
      id: id,
      name: name,
      email: email,
      username: username
    });
  }

  function handleRemove(id) {
    dispatch({
      type: 'remove',
      id: id,
    });
  }
  

  function usersReducer(users, action) {
    if (action.type === 'add') {
      return [
        ...users,
        {
          id: action.id,
          name: action.name,
          email: action.email,
          username: action.username
        },
      ];
    }
    
    else if(action.type === 'remove'){
      return users.filter((user) => user.id !== action.id)
    } 
    
    else if(action.type === 'edit'){
      return users.map((user) => {
        if(user.id === action.id){
          return {...user, name: action.name, email: action.email, username: action.username}
        } 
        else {
          return user
        }
      })
    }
  }


  return (
    <>
      <input type='text' onChange={(val) => setName(val.target.value)}/>
      <input type='text' onChange={(val) => setUsername(val.target.value)}/>
      <input type='text' onChange={(val) => setEmail(val.target.value)}/>
      <button onClick={() => handleAdd(name, email, username)}>Add</button>
      <ul>
        {users.map((user) =>{
          return(
            <li key={user.id}>
              <p>{user.name}</p>
              <p>{user.username}</p>
              <p>{user.email}</p>
              
              <div className='Buttons'>
                <button onClick={() => handleEdit(user.id, name, email, username)}>Edit</button>
                <button onClick={() => handleRemove(user.id)}>Remove</button>
              </div>
            </li>
          )
        })}
      </ul>
    </>
  )
}

export default App