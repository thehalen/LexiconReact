import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import Map from './Map';

class CommentBox extends React.Component {
  constructor(props) {
      super(props);
      this.state = { data: [] };
  }
  render() {
      return (
          <div className="commentBox">
              <h1>Comments</h1>
              <CommentList data={this.state.data} />
          </div>
      );
  }
}

class CommentList extends React.Component {
  render() {
      const commentNodes = this.props.data.map(comment => (
          <Comment author={comment.author} key={comment.id}>
              {comment.text}
          </Comment>
      ));
      return <div className="commentList">{commentNodes}</div>;
  }
}

class Comment extends React.Component {
  rawMarkup() {
      const md = new Remarkable();
      const rawMarkup = md.render(this.props.children.toString());
      return { __html: rawMarkup };
  }
  render() {
      return (
          <div className="comment">
              <h2 className="commentAuthor">{this.props.author}</h2>
              <span dangerouslySetInnerHTML={this.rawMarkup()} />
          </div>
      );
  }
}
// ReactDOM.render(
//   <React.StrictMode>
//   <CommentBox url="/comments" />,
//   </React.StrictMode>,
//   document.getElementById('root')
// );

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
