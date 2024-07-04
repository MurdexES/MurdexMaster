import { useCookies } from "react-cookie";
import { useState, useEffect } from "react";
import './UserPage.css'

function UserPage() {
    const [name, setName] = useState('')
    const [email, setEmail] = useState('')
    const [cookies, setCookies, removeCookies] = useCookies(['passwordHashed']);

    const handleRemove = async (e) => {
        e.preventDefault()
        
        const res = await fetch(`http://localhost:3000/remove?email=${email}&password=${cookies.passwordHashed}`,
            {
                method: 'POST'
            }
        );
        
        const data = await res.text()
        alert(data)
        
        if (data === 'Removed.') {
            removeCookies('passwordHashed')
            setTimeout(() => {
                window.location.href = '/logged'
            }, 2000)
        }
    }

    useEffect(() => {
        if (!cookies.passwordHashed) {
            window.location.href = '/'
        }
        
        fetch(`http://localhost:3000/verification?password=${cookies.passwordHashed}`)
            .then(response => response.json())
            .then(data => {
                if (!data.ok) {
                    removeCookies('passwordHashed')
                    window.location.href = '/'
                }else{
                    setName(data.data.name)
                }
            })
            .catch(error => console.error(error));
    }, [cookies.passwordHashed])

    return (
        <>
            <div className="box">
                <div className="header_box">
                    <h1>{name}</h1>
                    <hr/>
                </div>
                
                <input type="email" placeholder="Email" onChange={(e) => setEmail(e.target.value)} />

                <div className="buttons">
                    <button onClick={() => removeCookies('passwordHashed')}>Log Out</button>
                    <button onClick={handleRemove}>Remove</button>
                </div>
            </div>
        </>
    );
}

export default UserPage;