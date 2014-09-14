using System;
using NUnit.Framework;
using DNS.Protocol;

namespace DNS.Tests.Protocol {
    [TestFixture]
    public class SerializeQuestionTest {
        [Test]
        public void BasicQuestionWithEmptyDomain() {
            byte[] content = Helper.ReadFixture("Question", "empty-domain.basic");
            Domain domain = new Domain(Helper.GetArray<string>());
            Question question = new Question(domain, RecordType.A, RecordClass.IN);

            CollectionAssert.AreEqual(content, question.ToArray());
        }

        [Test]
        public void AnyQuestionWithEmptyDomain() {
            byte[] content = Helper.ReadFixture("Question", "empty-domain.cname");
            Domain domain = new Domain(Helper.GetArray<string>());
            Question question = new Question(domain, RecordType.CNAME, RecordClass.IN);

            CollectionAssert.AreEqual(content, question.ToArray());
        }

        [Test]
        public void CNameQuestionWithEmptyDomain() {
            byte[] content = Helper.ReadFixture("Question", "empty-domain.any");
            Domain domain = new Domain(Helper.GetArray<string>());
            Question question = new Question(domain, RecordType.A, RecordClass.ANY);

            CollectionAssert.AreEqual(content, question.ToArray());
        }

        [Test]
        public void CNameAndAnyQuestionWithEmptyDomain() {
            byte[] content = Helper.ReadFixture("Question", "empty-domain.cname.any");
            Domain domain = new Domain(Helper.GetArray<string>());
            Question question = new Question(domain, RecordType.CNAME, RecordClass.ANY);

            CollectionAssert.AreEqual(content, question.ToArray());
        }

        [Test]
        public void BasicQuestionWithMultipleLabelDomain() {
            byte[] content = Helper.ReadFixture("Question", "www.google.com-basic");
            Domain domain = new Domain(Helper.GetArray("www", "google", "com"));
            Question question = new Question(domain, RecordType.A, RecordClass.IN);

            CollectionAssert.AreEqual(content, question.ToArray());
        }
    }
}
