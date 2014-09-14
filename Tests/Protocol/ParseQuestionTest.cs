using System;
using NUnit.Framework;
using DNS.Protocol;

namespace DNS.Tests.Protocol {
    [TestFixture]
    public class ParseQuestionTest {
        [Test]
        public void BasicQuestionWithEmptyDomain() {
            int endOffset = 0;
            byte[] content = Helper.ReadFixture("Question", "empty-domain.basic");
            Question question = Question.FromArray(content, 0, out endOffset);

            Assert.AreEqual("", question.Name.ToString());
            Assert.AreEqual(RecordType.A, question.Type);
            Assert.AreEqual(RecordClass.IN, question.Class);
            Assert.AreEqual(5, question.Size);
            Assert.AreEqual(5, endOffset);
        }

        [Test]
        public void CNameQuestionWithEmptyDomain() {
            int endOffset = 0;
            byte[] content = Helper.ReadFixture("Question", "empty-domain.cname");
            Question question = Question.FromArray(content, 0, out endOffset);

            Assert.AreEqual("", question.Name.ToString());
            Assert.AreEqual(RecordType.CNAME, question.Type);
            Assert.AreEqual(RecordClass.IN, question.Class);
            Assert.AreEqual(5, question.Size);
            Assert.AreEqual(5, endOffset);
        }

        [Test]
        public void AnyQuestionWithEmptyDomain() {
            int endOffset = 0;
            byte[] content = Helper.ReadFixture("Question", "empty-domain.any");
            Question question = Question.FromArray(content, 0, out endOffset);

            Assert.AreEqual("", question.Name.ToString());
            Assert.AreEqual(RecordType.A, question.Type);
            Assert.AreEqual(RecordClass.ANY, question.Class);
            Assert.AreEqual(5, question.Size);
            Assert.AreEqual(5, endOffset);
        }

        [Test]
        public void CNameAndAnyQuestionWithEmptyDomain() {
            int endOffset = 0;
            byte[] content = Helper.ReadFixture("Question", "empty-domain.cname.any");
            Question question = Question.FromArray(content, 0, out endOffset);

            Assert.AreEqual("", question.Name.ToString());
            Assert.AreEqual(RecordType.CNAME, question.Type);
            Assert.AreEqual(RecordClass.ANY, question.Class);
            Assert.AreEqual(5, question.Size);
            Assert.AreEqual(5, endOffset);
        }

        [Test]
        public void CNameAndAnyQuestionWithMultipleLabelDomainPreceededByHeader() {
            int endOffset = 0;
            byte[] content = Helper.ReadFixture("Question", "empty-header.www.google.com-cname.any");
            Question question = Question.FromArray(content, 12, out endOffset);

            Assert.AreEqual("www.google.com", question.Name.ToString());
            Assert.AreEqual(RecordType.CNAME, question.Type);
            Assert.AreEqual(RecordClass.ANY, question.Class);
            Assert.AreEqual(20, question.Size);
            Assert.AreEqual(32, endOffset);
        }

        [Test]
        public void BasicQuestionWithMultipleLabelDomain() {
            int endOffset = 0;
            byte[] content = Helper.ReadFixture("Question", "www.google.com-basic");
            Question question = Question.FromArray(content, 0, out endOffset);

            Assert.AreEqual("www.google.com", question.Name.ToString());
            Assert.AreEqual(RecordType.A, question.Type);
            Assert.AreEqual(RecordClass.IN, question.Class);
            Assert.AreEqual(20, question.Size);
            Assert.AreEqual(20, endOffset);
        }
    }
}
