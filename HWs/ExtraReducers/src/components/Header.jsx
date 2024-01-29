import { Link } from "react-router-dom";

function Header(){
    return(
    <header>
        <nav>
            <Link to='/'><h1>MY SHOP</h1></Link>
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