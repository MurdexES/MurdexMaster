import {Link} from 'react-router-dom'

function Header({setQuery}){
    return(
        <header>
            <nav>
                <Link to='/'><h1>MY SHOP</h1></Link>
                <input type='text' placeholder='search for product...' onChange={(ev) => setQuery(ev.target.value)}/>
                <ul>
                    <li><Link to='/'>HOME</Link></li>
                    <li><Link to='/admin'>ADMIN</Link></li>
                    <li><Link to='/my-bag'>MY BAG</Link></li>
                </ul>
            </nav>
        </header>
    )
}

export default Header