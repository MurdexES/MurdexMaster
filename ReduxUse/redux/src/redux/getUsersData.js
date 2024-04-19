import { addingData, deletingData, editingData  } from "./reducer.js";

export function addData(obj){
    return function(dispatch){
        fetch('http://localhost:5000/add', {
            method:'POST',
            headers: {
                'Content-type' : 'application/json'
            },
        })
        .then(res => res.text())
        .then(data => dispatch(addingData(data)))
    }
}

export function deleteData(id){
    return function(dispatch){
        fetch(`http://localhost:5000/delete-admin/${id}`, {
            method: 'DELETE',
        })
        .then(res => res.text())
        .then(data => dispatch(deletingData(data)))
    }
}

export function editData(obj) {
    return function(dispatch) {
        fetch(`http://localhost:5000/change-admin/${obj.id}`, {
            method: 'PUT',
            headers: {
                'Content-type': 'application/json'
            },
            body:JSON.stringify(obj)
        })
        .then(res => res.text())
        .then(data => dispatch(editingData(data)))
    }
}