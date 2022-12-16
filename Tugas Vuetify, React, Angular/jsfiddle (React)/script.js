class App extends React.Component {
	constructor(props) {
  	super(props);
    this.state = {
        mkLi: [{
            id: 1, txt: 'Pengantar Teknik'
        }, {
            id: 0, txt: 'Dasar Pemrograman'
        }],
        newMK: '',
        idMK: 2,
        del: 0,
        add: 0
    }
}

removeMK(id) {
    let oldmk = this.state.mkLi;
    for(let i = 0; i < oldmk.length; i++) {
        if(id == oldmk[i].id) {
            oldmk.splice(i, 1);
            break;
        }
    }
    this.setState({
        mkLi: oldmk,
        del: 1
    })
}

removeAll() {
    let oldmk = this.state.mkLi;
    if(oldmk.length <= 0) {
        return;
    }

    oldmk.splice(0, oldmk.length);
    this.setState({
        mkLi: oldmk,
        del: 2
    })
}

addMK() {
    if(this.state.newMK.trim() == '') {
        return;
    }

    let newmk = {
        id: this.state.idMK,
        txt: this.state.newMK
    };
    let oldmk = this.state.mkLi;
    let oldid = this.state.idMK;
    oldid++;
    oldmk.push(newmk);
    this.setState({
    	newMK: '',
        mkLi: oldmk,
        idMK: oldid,
        add: 1
    })
}

changeMK(event) {
  	this.setState({
    	newMK: event.target.value
    })
}

handleSubmit(e) {
    e.preventDefault();
}

render() {
    let delP = '';
    if(this.state.del == 1) {
        delP = <p class="del">*Mata kuliah berhasil dihapus!</p>;
        this.state.del = 0;
    } else if(this.state.del == 2) {
        delP = <p class="del">*Mata kuliah berhasil dihapus semua!</p>;
        this.state.del = 0;
    } else if(this.state.add == 1) {
        delP = <p class="add">*Mata kuliah baru berhasil ditambah!</p>;
        this.state.add = 0;
    }

    let list = this.state.mkLi.map(
    (el) => {
        return <li key={el.id} onClick={this.removeMK.bind(this, el.id)} title="Hapus">&gt; {el.txt}</li>
    });
    return (
    <div class="container">
        <h1>Mata Kuliah</h1>
        <h3>S1 Teknik Informatika</h3>
        <hr/>
        <form onSubmit={this.handleSubmit.bind(this)}>
            <label for="inmk">
                <h5>Mata Kuliah Baru</h5>
            </label>
            <input id="inmk" type="text" value={this.state.newMK} onChange={this.changeMK.bind(this)} class="txt"></input>
            <button onClick= {this.addMK.bind(this)} type="submit">Tambah</button>
        </form>
        <h3 class="expl">Daftar Mata Kuliah</h3>
        <ul class="todoList">
            {list}
        </ul>
        <p title="Hapus Semua" class="expl" onClick={this.removeAll.bind(this)}>{this.state.mkLi.length} mata kuliah</p>
        {delP}
    </div>
    )
  }
}

ReactDOM.render(<App/>, document.querySelector('#app'))
