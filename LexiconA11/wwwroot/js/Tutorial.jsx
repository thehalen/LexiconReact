class AddPerson extends React.Component {
    constructor(props) {
        super(props);
        this.state = { name: '', cityId: '0', phoneNr: '', cities: []};
        this.handleNameUpdate = this.handleNameUpdate.bind(this);
        this.handlePhoneNrUpdate = this.handlePhoneNrUpdate.bind(this);
        this.handleCityUpdate = this.handleCityUpdate.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleNameUpdate(e) {
        this.setState({ name : e.target.value.trim() });
    }

    handlePhoneNrUpdate(e) {               
            this.setState({ phoneNr: e.target.value.trim() }); 
    }

    handleCityUpdate(e) {
        this.setState({ cityId: e.target.value });
    }

    handleSubmit(e) {
        e.preventDefault();
        if (!this.state.name || this.state.cityId=='0' || !this.state.phoneNr || this.state.phoneNr.match('\D'))
        {
            window.alert('Invalid input! Try again.');
        } else
        {
        this.props.submitForm({ name: this.state.name, phoneNr: this.state.phoneNr, cityId: this.state.cityId});
        this.setState({ name: '', phoneNr: '', cityId: '0'});
        }
    }
  
    render() {
        let Cities = this.props.cities.map(c =>
            <option key={c.cityId} value={c.cityId}>{c.name}</option>
        );
        return (
            <form id="addPersonForm" onSubmit={this.handleSubmit}>
                <label>&nbsp;Name:</label>
                <input
                    id="name"
                    type="text"
                    placeholder="Name"
                    value={this.state.name}
                    onChange={this.handleNameUpdate}
                />
                <label>&nbsp;Phone number:</label>
                <input
                    id="phoneNr"
                    type="text"
                    placeholder="Phone number"
                    value={this.state.phoneNr}
                    onChange={this.handlePhoneNrUpdate}
                />
                <label>&nbsp;City:</label>
                <select id="cityId" value={this.state.cityId} onChange={this.handleCityUpdate}><option value="0" hidden="hidden">Choose town</option>{Cities}</select>
                <input type="submit" value="Add" />
            </form>
        );
    }
}

class Details extends React.Component {
    render() {
        return (
            this.props.viewModel.map(pers =>
                <tr key={pers.personId}>
                    <td>{pers.personId}</td>
                    <td>{pers.name}</td>
                    <td>{pers.city}</td>
                    <td>{pers.phoneNr}</td>
                    <td>{pers.languages}</td>
                    <td><a onClick={() => this.props.deletePerson(pers.personId)} href="#">Remove</a></td>
                </tr>
            )
        );
    }
}

class PersonList extends React.Component {
    constructor(props) {
        super(props)
        this.state = { viewModel: [],
                       cities: [],
                       sortOrder : '🔽' };
        this.getData = this.getData.bind(this);
        this.submitPerson = this.submitPerson.bind(this);
        this.deletePerson = this.deletePerson.bind(this);
    }

    componentDidMount() {
        this.getData();
    }

    getData() {
        let xhr = new XMLHttpRequest();
        xhr.open('get', '/React/GetData', true);
        xhr.onload = () => {
            let data = JSON.parse(xhr.responseText);
            this.setState({ viewModel: data.personList});
            this.setState({ cities: data.cityList})};
        xhr.send();
    }

    submitPerson(person) { 
        let data = new FormData();
        data.append('Name', person.name);
        data.append('PhoneNr', person.phoneNr);
        data.append('CityId', person.cityId);

        let xhr = new XMLHttpRequest();
        xhr.open('post', '/React/AddPerson', true);
        xhr.onload = () => this.getData();
        xhr.send(data);
    }

    deletePerson(id) {
        let xhr = new XMLHttpRequest();
        xhr.open('post', '/React/DeletePersonById?personID=' + id, true);
        xhr.onload = () => this.getData();
        xhr.send();
    }

    sortList = event => {
        if (event.target.innerText=='🔽') {
            event.target.innerText='🔼';
            this.setState({ viewModel: this.state.viewModel.sort((a, b) => (a.name > b.name) ? 1 : -1) });
        } else {
            event.target.innerText='🔽';
            this.setState({ viewModel: this.state.viewModel.sort((a, b) => (a.name < b.name) ? 1 : -1) });            
        }  
    }

    render() {
            return (<div id="basic">
                <AddPerson submitForm={this.submitPerson} cities={this.state.cities}/>
                <table style={{width: "70%"}}>
                    <caption>Persons:</caption>
                    <thead>
                        <tr>
                            <th>Id</th> 
                            <th>Name<span id="sorting" onClick={this.sortList}>{this.state.sortOrder}</span></th>
                            <th>City</th>
                            <th>Phone</th>
                            <th>Languages</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <Details viewModel={this.state.viewModel} deletePerson={this.deletePerson} />
                    </tbody>
                </table>                    
                </div>
            );
        }
    }


ReactDOM.render(
    <PersonList/>,
    document.getElementById('content')
);
