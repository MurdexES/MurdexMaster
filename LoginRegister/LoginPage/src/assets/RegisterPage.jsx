import { useCookies } from "react-cookie";
import { useState, useEffect } from 'react'

function RegisterPage() {
    const [name, setName] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [cookies, setCookies] = useCookies()

    useEffect(() => {
        if (cookies.passwordHashed) {
            fetch(`http://localhost:3000/verification?password=${cookies.passwordHashed}`)
            .then(response => response.json())
            .then(data => {
                if (data.ok) {
                    setTimeout(() => {
                        window.location.href = '/logged'
                    }, 2000)
                } else {
                    console.log(data.message)
                }
            })
            .catch(error => console.error(error));
        }
    }, [cookies.passwordHashed])
  
    const handleRegister = async (e) => {
      e.preventDefault()
      const res = await fetch(`http://localhost:3000/register?name=${name}&email=${email}&password=${password}`,
        {
          method: 'POST'
        }
      )
      
      const data = await res.text()
      console.log(data);
    }
    
    const handleLogin = async (e) => {
      e.preventDefault()
      const res = await fetch(`http://localhost:3000/login?email=${email}&password=${password}`,
        {
          method: 'POST'
        }
      )
      const data = await res.json()
      
      if (data.ok) {
        setCookies('passwordHashed', data.password)
        console.log(data.message)
      } else {
        console.log(data.message)
      }
    }
    return (
        <>
            <div>
                <form onSubmit={handleRegister}>
                    <input placeholder='name' type="text" name='name' onChange={(e) => setName(e.target.value)} />
                    <input placeholder='email' type="email" name='email' onChange={(e) => setEmail(e.target.value)} />
                    <input placeholder='password' type="password" name='password' onChange={(e) => setPassword(e.target.value)} />
                    
                    <button type="submit">Sign in</button>
                </form>
                
                <form onSubmit={handleLogin}>
                    <input placeholder='email' type="email" name='email' onChange={(e) => setEmail(e.target.value)} />
                    <input placeholder='password' type="password" name='password' onChange={(e) => setPassword(e.target.value)} />
                    
                    <button type="submit">Log In</button>
                </form>
            </div>
        </>
    );
}

export default RegisterPage;