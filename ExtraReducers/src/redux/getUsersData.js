import { addingData, deletingData } from './reducer'

export function fecthAddData(obj){
    return function(dispatch){
        fetch('http://localhost:5000/add-admin', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body:JSON.stringify(obj)
        })
        .then(res => res.text())
        .then(data => dispatch(addingData(data)))
    }
}

export function fecthDeleteData(id){
    return function(dispatch){
        fetch('http://localhost:5000/delete-admin/' + id, {
            method:'DELETE',
        })
        .then(res => res.text())
        .then(data => dispatch(deletingData(data)))
    }
}