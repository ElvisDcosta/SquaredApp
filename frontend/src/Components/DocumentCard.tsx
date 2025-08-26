import React from "react";

type Props = {};

const DocumentCard = (props: Props) => {
  return (
    <div className="d-grid gap-2 d-md-flex justify-content-md-end">
      {" "}
      <div
        style={{
          display: "flex",
          gap: "10px",
          padding: "10px",
        }}
      >
        <input
          type="text"
          id="Group1"
          placeholder="Document ID"
          style={{ width: "250px" }}
        ></input>
        <input
          type="text"
          id="Group1"
          placeholder="Document Name"
          style={{ width: "250px" }}
        ></input>
        <input
          type="text"
          id="Group1"
          placeholder="Customer Name"
          style={{ width: "250px" }}
        ></input>
        <input
          type="text"
          id="Group1"
          placeholder="Expiry Date"
          style={{ width: "250px" }}
        ></input>
      </div>
      <div
        className="d-grid gap-2 d-md-flex justify-content-md-end"
        style={{
          display: "flex",
          gap: "10px",
          padding: "10px",
        }}
      >
        <button type="button" className="btn btn-info me-md-2">
          Update
        </button>
        <button type="button" className="btn btn-danger me-md-2">
          Delete
        </button>
      </div>
    </div>
  );
};

export default DocumentCard;
