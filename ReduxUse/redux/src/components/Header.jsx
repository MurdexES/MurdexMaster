import {Link} from 'react-router-dom'
import { Row, Col } from 'antd'

function Header({setQuery}){
    return(
        <header>
            <nav>
                <Col>
                    <Link to='/'><h1>MY SHOP</h1></Link>
                    <Row>
                        <input type='text' placeholder='search for product...' onChange={(ev) => setQuery(ev.target.value)}/>
                        <ul>
                            <li><Link to='/'>HOME</Link></li>
                            <li><Link to='/admin'>ADMIN</Link></li>
                            <li><Link to='/my-bag'>MY BAG</Link></li>
                        </ul>
                    </Row>
                </Col>
            </nav>
        </header>
    )
}

export default Header